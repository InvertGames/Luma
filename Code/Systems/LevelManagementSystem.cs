using Invert.IOC;
using UnityEngine;

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

        public RunningLevel CurrentActiveLevel { get; set; }

        public override void Loaded()
        {
            base.Loaded();
        }

        protected override void LevelSceneDataCreated(LevelSceneData data, LevelSceneData @group)
        {
            base.LevelSceneDataCreated(data, @group);
            Debug.Log("Here");
            if(LevelDependencies != null)
            foreach (var levelDependency in LevelDependencies)
            {
                    Debug.Log(string.Format("adding {0} for {1}", levelDependency.Name, data.SceneData.Name));
                    data.SceneData.Dependency.Add(levelDependency);
            }
        }

        protected override void LevelStarted(RunningLevel data, RunningLevel @group)
        {
            base.LevelStarted(data, @group);
            CurrentActiveLevel = data;
        }

        protected override void RunningLevelComponentDestroyed(RunningLevel data, RunningLevel @group)
        {
            base.RunningLevelComponentDestroyed(data, @group);
            CurrentActiveLevel = RunningLevelManager.Components.Except(new[] {data}).FirstOrDefault();
        }

        private void OnGUI()
        {
            if (CurrentActiveLevel == null) return;
            if (GUILayout.Button(string.Format("Unload Level {0}", CurrentActiveLevel.SceneInstance.SceneData.Name)))
            {
                this.Publish(new DeconstructScene()
                {
                    SceneInstance = CurrentActiveLevel.SceneInstance.EntityId,
                    DeconstructDependencies = true
                });
            }
        }

        protected override void LevelManagementSystemLoadLevelHandler(LoadLevel data, LevelData level)
        {
            base.LevelManagementSystemLoadLevelHandler(data, level);
            if (CurrentActiveLevel != null)
            {
                this.Publish(new ExchangeScenes()
                {
                    Load = level.EntityId,
                    Unload = CurrentActiveLevel.EntityId
                });
            }
            else
            {
                this.Publish(new ConstructScene()
                {
                    SceneData = level.EntityId
                });
            }
        }

        protected override void LevelManagementSystemUnloadAllLevelsHandler(UnloadAllLevels data)
        {
            base.LevelManagementSystemUnloadAllLevelsHandler(data);
            this.Publish(new DeconstructScene()
            {
                DeconstructDependencies = true,
                SceneInstance = CurrentActiveLevel.EntityId
            });
        }

        //public override void Setup()
        //{
        //    base.Setup();
        //    OnEvent<SceneLoaderEvent>().Where(s => s.State == SceneState.Loaded).Subscribe(OnSceneLoaded);
        //    OnEvent<SceneLoaderEvent>().Where(s => s.State == SceneState.Unloaded).Subscribe(OnSceneUnloaded);
        //}

        //private void OnSceneUnloaded(SceneLoaderEvent evt)
        //{
        //    if (CurrentActiveLevel == null || evt.SceneRoot.Name == CurrentActiveLevel.EntityId.ToLevelName()) return;
        //    WaitingToUnload.Remove(evt.SceneRoot.Name);
        //    CheckIfLevelUnloaded();
        //}

        //private void OnSceneLoaded(SceneLoaderEvent evt)
        //{
        //    if (CurrentActiveLevel == null || evt.SceneRoot.Name == CurrentActiveLevel.EntityId.ToLevelName()) return;
        //    WaitingToLoad.Remove(evt.SceneRoot.Name);
        //    CheckIfLevelLoaded();
        //}

        //private void CheckIfLevelLoaded()
        //{
        //    if (!WaitingToLoad.Any())
        //    {
        //        CurrentActiveLevel.State = LevelState.Loaded;
        //    }
        //}

        //private void CheckIfLevelUnloaded()
        //{
        //    if (!WaitingToUnload.Any())
        //    {
        //        CurrentActiveLevel.State = LevelState.Inactive;
        //        CurrentActiveLevel = null;
        //    }
        //}

        //public List<string> WaitingToLoad
        //{
        //    get { return _waitingToLoad ?? (_waitingToLoad = new List<string>()); }
        //    set { _waitingToLoad = value; }
        //}

        //public List<string> WaitingToUnload
        //{
        //    get { return _waitingToUnload ?? (_waitingToUnload = new List<string>()); }
        //    set { _waitingToUnload = value; }
        //}

        //protected override void LevelManagementSystemOnRunningLevelCreated(RunningLevel data, RunningLevel @group)
        //{
        //    base.LevelManagementSystemOnRunningLevelCreated(data, @group);
        //    if (CurrentActiveLevel == null) CurrentActiveLevel = data.LevelData;
        //    CurrentActiveLevel.State = LevelState.Loading;
        //    WaitingToLoad.AddRange(LevelDependencyScenes);
        //    WaitingToLoad.AddRange(data.LevelData.SceneDependencies);
        //    WaitingToLoad.LoadScenes(true);
        //    CheckIfLevelLoaded();
        //}

        //protected override void RunningLevelComponentDestroyed(RunningLevel data, RunningLevel @group)
        //{
        //    base.RunningLevelComponentDestroyed(data, @group);
        //    CurrentActiveLevel.State = LevelState.Unloading;
        //    WaitingToUnload.AddRange(LevelDependencyScenes);
        //    WaitingToUnload.AddRange(data.LevelData.SceneDependencies);
        //    WaitingToUnload.UnloadScenes();
        //    CheckIfLevelUnloaded();
        //}

        //protected override void LevelManagementSystemOnGameReadyHandler(GameReadyEvent data)
        //{
        //    base.LevelManagementSystemOnGameReadyHandler(data);
        //    GameDependencyScenes.LoadScenes(true);
        //}

        //protected override void LevelManagementSystemLoadLevelHandler(LoadLevel data, LevelData source)
        //{
        //    //Publish Level Loading Event
        //    CurrentActiveLevel = source;
        //    CurrentActiveLevel.State = LevelState.Loading;
        //    this.Publish(new LoadSceneCommand()
        //    {
        //        SceneName = source.EntityId.ToLevelName()
        //    });
        //}

        //protected override void LevelManagementSystemUnloadLevelHandler(UnloadLevel data, RunningLevel source)
        //{
        //    //Publish Level Unloading Event
        //    CurrentActiveLevel.State = LevelState.Unloading;
        //    this.Publish(new UnloadSceneCommand()
        //    {
        //        SceneName = CurrentActiveLevel.EntityId.ToLevelName()
        //    });
        //}

    }


    public static class FlipCubeEntityExtensions
    {
        public static string ToLevelName(this int levelId)
        {
            return string.Format("Level{0}", levelId - 100);
        }
    }

    public static class FlipCubeLevelManagementExtension
    {
        public static void UnloadScenes(this IEnumerable<string> scenes)
        {
            if (scenes == null) return;
            foreach (var gameScenes in scenes)
            {
                uFrameKernel.EventAggregator.Publish(new UnloadSceneCommand()
                {
                    SceneName = gameScenes
                });
            }
        }

        public static void LoadScenes(this IEnumerable<string> scenes,bool single)
        {
            if (scenes == null) return;
            foreach (var gameScenes in scenes)
            {
                uFrameKernel.EventAggregator.Publish(new LoadSceneCommand()
                {
                    SceneName = gameScenes,
                    RestrictToSingleScene = single
                });
            }
        }
    }

}
