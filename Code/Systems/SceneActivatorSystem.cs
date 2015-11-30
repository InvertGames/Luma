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
                SceneDatas.Add(sceneData.Name, sceneData);
        }

        protected override void SceneDataCreated(SceneData data, SceneData @group)
        {
            base.SceneDataCreated(data, @group);
            SceneDatas.Add(data.Name,data);
        }

        protected override void SceneInstanceCreated(SceneInstance data, SceneInstance @group)
        {
            base.SceneInstanceCreated(data, @group);

            if (CurrentOperation != null)
            {
                data.SceneDataName = CurrentOperation.SceneData.Name;
            }

            data.SceneData = SceneDatas[data.SceneDataName];
            SceneInstances.Add(data.SceneDataName, data);

            if (CurrentOperation == null)
            {
                EnqueueLoadDependenciesFor(data.SceneData);
            }
            
            ExecuteNextOp();
        }

        private void EnqueueLoadDependenciesFor(SceneData sourceSceneData)
        {

            if (sourceSceneData.Dependency.Count == 0) return;

            foreach (var sceneData in sourceSceneData.Dependency)
            {
                if (!SceneInstances.ContainsKey(sceneData.Name) && OpQueue.All(i=>i.SceneData != sceneData))
                {
                    OpQueue.Enqueue(new SceneActivatorOperation()
                    {
                        Operation = OperationType.Load,
                        SceneData = sceneData
                    });
                }

                EnqueueLoadDependenciesFor(sceneData);
            }
        }

        private void ExecuteNextOp()
        {
            if (OpQueue.Count == 0) return; //Publish that scene queue was loaded
            CurrentOperation = OpQueue.Dequeue();
            StartCoroutine(RunCurrentOperation());
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
                        yield return null;
                    }
                    break;
                case OperationType.Unload:
                    //var unloadOp = Application.UnloadLevel(CurrentOperation.SceneData.Name);
                    Destroy(CurrentOperation.SceneInstance);
                    //while (!unloadOp.isDone) yield return null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            yield break;
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
