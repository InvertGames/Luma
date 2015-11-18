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

        [Inject]
        public SceneManagementService SceneManagementService { get; set; }

        public bool AreDepsLoaded { get; set; }

        protected override void OnLevelSceneLoaded(LevelScene data, LevelScene @group)
        {
            base.OnLevelSceneLoaded(data, @group);
            this.Publish(new LoadDependencyScenes());
        }

        protected override void OnLoadDepsHandler(LoadDependencyScenes data)
        {
            base.OnLoadDepsHandler(data);
            if (!AreDepsLoaded)
            {
                if (SceneManagementService.LoadedScenes.All(s => s.Name != "UIScene"))
                {
                    this.Publish(new LoadSceneCommand()
                    {
                        SceneName = "UIScene"
                    });
                }
                AreDepsLoaded = true;
            }
        }

        protected override void OnLevelLoaded(RunningLevel data, RunningLevel @group)
        {
            base.OnLevelLoaded(data, @group);
            UnityEngine.Debug.Log("LEvel loaded: "+data.EntityId);
        }
    }

    
}
