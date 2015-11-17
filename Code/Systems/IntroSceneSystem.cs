using UnityEngine;

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    using uFrame.ECS;
    using uFrame.Kernel;
    using FlipCube;
    
    
    public partial class IntroSceneSystem : IntroSceneSystemBase {

        private GoTweenConfig _fadeInTweenConfig;
        private GoTweenConfig _fadeOutTweenConfig;

        public GoTweenConfig FadeInTweenConfig
        {
            get { return _fadeInTweenConfig ?? (_fadeInTweenConfig = new GoTweenConfig()
                    .addTweenProperty(new FloatTweenProperty("alpha",1))); }
            set { _fadeInTweenConfig = value; }
        }

        public GoTweenConfig FadeOutTweenConfig
        {
            get { return _fadeOutTweenConfig ?? (_fadeOutTweenConfig = new GoTweenConfig()
                    .localPosition(new Vector3(-1000,0))
                    .setEaseType(GoEaseType.ElasticInOut)
                    .setDelay(2f)); }
            set { _fadeOutTweenConfig = value; }
        }

        protected override void OnPlayIntro(Intro data, Intro group)
        {
            data.Logo.alpha = 0;
            Go.to(data.Logo,1f,FadeInTweenConfig).setOnCompleteHandler(x =>
            {
                Go.to(data.Logo.transform, 1f, FadeOutTweenConfig).setOnCompleteHandler(y =>
                {
                    Destroy(data);
                });
            });
        }


        protected override void IntroComponentDestroyed(Intro data, Intro group) {
            this.Publish(new UnloadSceneCommand()
            {
                SceneName = "IntroScene"
            });

            this.Publish(new LoadSceneCommand()
            {
                SceneName = "UIScene"
            });
        }

    }
}
