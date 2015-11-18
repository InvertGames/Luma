namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FlipCube;
    using uFrame.Kernel;
    using uFrame.ECS;
    using UniRx;
    
    
    public partial class FlipCubeLevelSystem : FlipCubeLevelSystemBase {
        protected override void FlipCubeLevelSystemLevelFailedHandler(LevelFailed data)
        {
            //base.FlipCubeLevelSystemLevelFailedHandler(data);
            Observable.Timer(TimeSpan.FromSeconds(LevelResetTime)).Subscribe(_ =>
            {
                this.Publish(new LevelReset());
            });
        }

        protected override void FlipCubeLevelSystemPlayerFallHandler(PlayerFall data, Player player)
        {
            //base.FlipCubeLevelSystemPlayerFallHandler(data, player);
            this.Publish(new LevelFailed());
        }
    }
}
