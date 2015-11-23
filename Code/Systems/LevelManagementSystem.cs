using Invert.IOC;

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FlipCube;
    using uFrame.Kernel;
    using UniRx;
    using uFrame.ECS;

    public partial class LevelManagementSystem
    {
        private List<string> _waitingToLoad;
        private List<string> _waitingToUnload;

        [Inject]
        public SceneManagementService SceneManagementService { get; set; }

        public LevelData CurrentActiveLevel { get; set; }

        public override void Setup()
        {
            base.Setup();
            OnEvent<SceneLoaderEvent>().Where(s => s.State == SceneState.Loaded).Subscribe(OnSceneLoaded);
            OnEvent<SceneLoaderEvent>().Where(s => s.State == SceneState.Unloaded).Subscribe(OnSceneUnloaded);
        }

        private void OnSceneUnloaded(SceneLoaderEvent evt)
        {
            if (CurrentActiveLevel == null || evt.SceneRoot.Name == "Level"+(CurrentActiveLevel.EntityId - 100)) return;
            if (WaitingToUnload.Contains(evt.SceneRoot.Name)) WaitingToUnload.Remove(evt.SceneRoot.Name);
            CheckIfLevelUnloaded();
        }

        private void OnSceneLoaded(SceneLoaderEvent evt)
        {
            if (CurrentActiveLevel == null || evt.SceneRoot.Name == "Level" + (CurrentActiveLevel.EntityId - 100)) return;
            if (WaitingToLoad.Contains(evt.SceneRoot.Name)) WaitingToLoad.Remove(evt.SceneRoot.Name);
            CheckIfLevelLoaded();
        }

        private void CheckIfLevelLoaded()
        {
            if (!WaitingToLoad.Any())
            {
                CurrentActiveLevel.State = LevelState.Loaded;
            }
        }

        private void CheckIfLevelUnloaded()
        {
            if (!WaitingToUnload.Any())
            {
                CurrentActiveLevel.State = LevelState.Inactive;
                CurrentActiveLevel = null;
            }
        }

        public List<string> WaitingToLoad
        {
            get { return _waitingToLoad ?? (_waitingToLoad = new List<string>()); }
            set { _waitingToLoad = value; }
        }

        public List<string> WaitingToUnload
        {
            get { return _waitingToUnload ?? (_waitingToUnload = new List<string>()); }
            set { _waitingToUnload = value; }
        }

        protected override void LevelManagementSystemOnRunningLevelCreated(RunningLevel data, RunningLevel @group)
        {
            base.LevelManagementSystemOnRunningLevelCreated(data, @group);
            if (CurrentActiveLevel == null) CurrentActiveLevel = data.LevelData;  
            CurrentActiveLevel.State = LevelState.Loading;
            WaitingToLoad.AddRange(LevelDependencyScenes);
            WaitingToLoad.AddRange(data.LevelData.SceneDependencies);
            LoadScenesIfNotLoaded(WaitingToLoad);
            CheckIfLevelLoaded();
        }

        protected override void RunningLevelComponentDestroyed(RunningLevel data, RunningLevel @group)
        {
            base.RunningLevelComponentDestroyed(data, @group);
            CurrentActiveLevel.State = LevelState.Unloading;
            WaitingToUnload.AddRange(LevelDependencyScenes);
            WaitingToUnload.AddRange(data.LevelData.SceneDependencies);
            UnloadScenesIfLoaded(WaitingToUnload);
            CheckIfLevelUnloaded();
        }
        
        protected override void LevelManagementSystemOnGameReadyHandler(GameReadyEvent data)
        {
            base.LevelManagementSystemOnGameReadyHandler(data);
            LoadScenesIfNotLoaded(GameDependencyScenes);
        }

        protected override void LevelManagementSystemLoadLevelHandler(LoadLevel data, LevelData source)
        {
            //Publish Level Loading Event
            CurrentActiveLevel = source;
            CurrentActiveLevel.State = LevelState.Loading;
            this.Publish(new LoadSceneCommand()
            {
                SceneName = ("Level"+(source.EntityId - 100))
            });
        }

        protected override void LevelManagementSystemUnloadLevelHandler(UnloadLevel data, RunningLevel source)
        {
            //Publish Level Unloading Event
            CurrentActiveLevel.State = LevelState.Unloading;
            this.Publish(new UnloadSceneCommand()
            {
                SceneName = ("Level" + (CurrentActiveLevel.EntityId - 100))
            });
        }

        private void LoadScenesIfNotLoaded(IEnumerable<string> scenes)
        {
            if (scenes == null) return;
            foreach (var gameScenes in scenes)
            {
                this.Publish(new LoadSceneCommand()
                {
                    SceneName = gameScenes,
                    RestrictToSingleScene = true
                });
            }
        }

        private void UnloadScenesIfLoaded(IEnumerable<string> scenes)
        {
            if (scenes == null) return;
            foreach (var gameScenes in scenes)
            {
                this.Publish(new UnloadSceneCommand()
                {
                    SceneName = gameScenes
                });
            }
        }


    }


}
