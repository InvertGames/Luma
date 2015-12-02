using System.Runtime.Remoting.Messaging;

namespace FlipCube {
    using FlipCube;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using uFrame.Kernel;
    using UniRx;
    using UnityEngine;
    
    
    public partial class SceneActivatorSystem {

        private Queue<SceneActivatorOperation> _opQueue;
        private Dictionary<string, SceneData> _sceneDatas;
        private Dictionary<string, SceneInstance> _sceneInstances;

        public Queue<SceneActivatorOperation> OpQueue
        {
            get { return _opQueue ?? (_opQueue = new Queue<SceneActivatorOperation>()); }
            set { _opQueue = value; }
        }

        public Dictionary<string, SceneData> SceneDatas
        {
            get { return _sceneDatas ?? (_sceneDatas = new Dictionary<string, SceneData>()); }
            set { _sceneDatas = value; }
        }

        public Dictionary<string, SceneInstance> SceneInstances
        {
            get { return _sceneInstances ?? (_sceneInstances = new Dictionary<string, SceneInstance>()); }
            set { _sceneInstances = value; }
        }

        public SceneActivatorOperation CurrentOperation { get; private set; }

        public override void Setup()
        {
            base.Setup();
            foreach (var sceneData in gameObject.GetComponentsInChildren<SceneData>())
            {
                if (string.IsNullOrEmpty(sceneData.Name)) sceneData.Name = sceneData.gameObject.name;
                SceneDatas.Add(sceneData.Name, sceneData);
            }
        }

        protected override void SceneDataCreated(SceneData data, SceneData @group)
        {
            base.SceneDataCreated(data, @group);
            if (string.IsNullOrEmpty(data.Name)) data.Name = data.gameObject.name;
            if(!SceneDatas.ContainsKey(data.Name)) SceneDatas.Add(data.Name,data);
        }

        protected override void SceneInstanceCreated(SceneInstance data, SceneInstance @group)
        {
            base.SceneInstanceCreated(data, @group);

            if (CurrentOperation != null)
            {
                data.SceneDataName = CurrentOperation.SceneData.Name;
            }
            else
            {
                data.SceneDataName = Application.loadedLevelName;
            }

            data.SceneData = SceneDatas[data.SceneDataName];
            data.SceneData.Instances.Add(data);

            SceneInstances.Add(data.SceneDataName, data);



            if (CurrentOperation == null)
            {
                Observable.TimerFrame(1, FrameCountType.Update).Subscribe(_ =>
                {
                    EnqueueDependenciesFor(data.SceneData);
                    if (OpQueue.Count > 0) Publish(new SceneOperationsStarted());
                });
            }

        }

        private void EnqueueDependenciesFor(SceneData data)
        {
            var toLoad =
              GetFullDependenciesFor(data)
              .Where(d => !SceneInstances.ContainsKey(d.Name) && OpQueue.All(o => o.SceneData != d));

            foreach (var sceneData in toLoad)
            {
                OpQueue.Enqueue(new SceneActivatorOperation()
                {
                    Operation = OperationType.Load,
                    SceneData = sceneData
                });
            }
        }

        private HashSet<SceneData> GetFullDependenciesFor(SceneData sourceSceneData, HashSet<SceneData> deps = null)
        {
            deps = deps ?? new HashSet<SceneData>();
            if (sourceSceneData.Dependency.Count == 0) return deps;
            foreach (var sceneData in sourceSceneData.Dependency)
            {
                deps.Add(sceneData);
                GetFullDependenciesFor(sceneData,deps);
            }
            return deps;
        }

        protected override void GameDependencySceneDataCreated(GameDependencySceneData data, GameDependencySceneData @group)
        {
            base.GameDependencySceneDataCreated(data, @group);
            this.Publish(new ConstructScene()
            {
                SceneData = data.EntityId
            });
        }

        protected override void SceneInstanceComponentDestroyed(SceneInstance data, SceneInstance @group)
        {
            base.SceneInstanceComponentDestroyed(data, @group);
            SceneInstances.Remove(@group.SceneDataName);
        }

        protected override void SceneActivatorSystemConstructSceneHandler(ConstructScene data, SceneData scenedata)
        {
            base.SceneActivatorSystemConstructSceneHandler(data, scenedata);
            if (SceneInstances.ContainsKey(scenedata.Name)) return;
            OpQueue.Enqueue(new SceneActivatorOperation()
            {
                SceneData = scenedata,
                Operation = OperationType.Load
            });

            Publish(new SceneOperationsStarted());


            EnqueueDependenciesFor(scenedata);
        }

        void Update()
        {
            if (OpQueue.Count != 0 && CurrentOperation == null)
            {
                CurrentOperation = OpQueue.Dequeue();
                ExecuteNextOp();
            }
        }

        private void ExecuteNextOp()
        {
            if (CurrentOperation != null) StartCoroutine(RunCurrentOperation());
        }

        protected override void SceneActivatorSystemDeconstructSceneHandler(DeconstructScene data, SceneInstance sceneinstance)
        {
            base.SceneActivatorSystemDeconstructSceneHandler(data, sceneinstance);

            OpQueue.Enqueue(new SceneActivatorOperation()
            {
                SceneInstance = sceneinstance,
                Operation = OperationType.Unload
            });

            Publish(new SceneOperationsStarted());


            if (!data.DeconstructDependencies) return;
            var deps = GetFullDependenciesFor(sceneinstance.SceneData);
            var depsToUnload = SceneInstances.Where(s => deps.Contains(s.Value.SceneData)).Select(s => s.Value);

            foreach (var depInstance in depsToUnload)
            {
                OpQueue.Enqueue(new SceneActivatorOperation()
                {
                    SceneInstance = depInstance,
                    Operation = OperationType.Unload
                });
            }

        }

        protected override void SceneActivatorSystemExchangeScenesHandler(ExchangeScenes data, SceneInstance unload, SceneData load)
        {
            base.SceneActivatorSystemExchangeScenesHandler(data, unload, load);



            if (!SceneInstances.ContainsKey(load.Name))
            {
                OpQueue.Enqueue(new SceneActivatorOperation()
                {
                    SceneData = load,
                    Operation = OperationType.Load
                });
            }

            OpQueue.Enqueue(new SceneActivatorOperation()
            {
                SceneInstance = unload,
                Operation = OperationType.Unload
            });

            Publish(new SceneOperationsStarted());

            var newSceneDeps = GetFullDependenciesFor(load);
            var oldSceneDeps = GetFullDependenciesFor(unload.SceneData);

            foreach (var oldSceneDep in oldSceneDeps.Except(newSceneDeps).Select(d=>SceneInstances[d.Name]))
            {
                OpQueue.Enqueue(new SceneActivatorOperation()
                {
                    SceneInstance = oldSceneDep,
                    Operation = OperationType.Unload
                });
            }

            foreach (var sceneData in newSceneDeps.Where(d => !SceneInstances.ContainsKey(d.Name) && OpQueue.All(o => o.SceneData != d)))
            {
                OpQueue.Enqueue(new SceneActivatorOperation()
                {
                    SceneData = sceneData,
                    Operation = OperationType.Load
                });
            }

        }

        private IEnumerator RunCurrentOperation()
        {
            switch (CurrentOperation.Operation)
            {
                case OperationType.Load:
                    var loadOp = Application.LoadLevelAdditiveAsync(CurrentOperation.SceneData.Name);
                    while (!loadOp.isDone)
                    {
                        CurrentOperation.Progress = loadOp.progress;
                        PublishCurrentOpProgress(loadOp.progress);
                        yield return new WaitForSeconds(0.1f);
                    }
                    break;
                case OperationType.Unload:
                    //var unloadOp = Application.UnloadLevel(CurrentOperation.SceneData.Name);
                    PublishCurrentOpProgress(0f, false);
                    Destroy(CurrentOperation.SceneInstance.gameObject);
                    PublishCurrentOpProgress(1f,false);
                    //while (!unloadOp.isDone) yield return null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            CurrentOperation = null;
            if (OpQueue.Count == 0) Publish(new SceneOperationsFinished());
            yield break;
        }

        private void PublishCurrentOpProgress(float progress, bool loading = true)
        {
            this.Publish(new SceneOperationsProgress()
            {
                SceneProgress = progress,
                TargetData = CurrentOperation.SceneData,
                TargetInstance = CurrentOperation.SceneInstance,
                Loading = loading
            });
        }
    }


    public class SceneActivatorOperation
    {
        public SceneData SceneData { get; set; }
        public SceneInstance SceneInstance { get; set; }
        public OperationType Operation { get; set; }
        public float Progress { get; set; }
    }

    public enum OperationType
    {
        Load,
        Unload
    }
}
