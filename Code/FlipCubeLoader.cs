// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.ECS;
    
    
    public partial class FlipCubeLoader : uFrame.Kernel.SystemLoader {
        
        public override void Load() {
            EcsSystem system = null;
            system = this.AddSystem<MainMenuSystem>();
            system = this.AddSystem<PlayFabPlayerStatsSystem>();
            system = this.AddSystem<PlayerDataSystem>();
            system = this.AddSystem<SettingsSystem>();
            system = this.AddSystem<DisolvePlateSystem>();
            system = this.AddSystem<NotificationSystem>();
            system = this.AddSystem<PlayerStatsSystem>();
            system = this.AddSystem<PlayerInputSystem>();
            system = this.AddSystem<PlayfabTitleDataSystem>();
            system = this.AddSystem<PlayerGravitySystem>();
            system = this.AddSystem<FlipCubeLevelSystem>();
            system = this.AddSystem<PlayFabPlayerDataSystem>();
            system = this.AddSystem<DemoPlayerSystem>();
            system = this.AddSystem<LevelSystem>();
            system = this.AddSystem<LoginSystem>();
            system = this.AddSystem<TeliporterPlateSystem>();
            system = this.AddSystem<GameUISystem>();
            system = this.AddSystem<PlayerSystem>();
            system = this.AddSystem<LoginUISystem>();
            system = this.AddSystem<GameSystem>();
            system = this.AddSystem<PlateSystem>();
            system = this.AddSystem<PlayfabLoginSystem>();
            system = this.AddSystem<SwitchPlateSystem>();
            system = this.AddSystem<SoundSystem>();
            system = this.AddSystem<MiscUISystem>();
            system = this.AddSystem<DialogUISystem>();
            system = this.AddSystem<RollerSystem>();
            system = this.AddSystem<LevelManagementSystem>();
            system = this.AddSystem<IntroSceneSystem>();
            system = this.AddSystem<NotificationsUISystem>();
        }
    }
}
