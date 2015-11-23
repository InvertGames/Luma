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
    using uFrame.ECS;
    using uFrame.Kernel;
    
    
    public partial class FlipCubeLoader : uFrame.Kernel.SystemLoader {
        
        public override void Load() {
            EcsSystem system = null;
            system = this.AddSystem<UIWidgetSystem>();
            system = this.AddSystem<PlayFabPlayerStatsSystem>();
            system = this.AddSystem<PlayerDataSystem>();
            system = this.AddSystem<LevelSelectionUISystem>();
            system = this.AddSystem<SettingsSystem>();
            system = this.AddSystem<DisolvePlateSystem>();
            system = this.AddSystem<NotificationSystem>();
            system = this.AddSystem<PlayerStatsSystem>();
            system = this.AddSystem<PlayerInputSystem>();
            system = this.AddSystem<PlayfabTitleDataSystem>();
            system = this.AddSystem<PlayerGravitySystem>();
            system = this.AddSystem<GameAudioSystem>();
            system = this.AddSystem<FlipCubeLevelSystem>();
            system = this.AddSystem<PlayFabPlayerDataSystem>();
            system = this.AddSystem<DemoPlayerSystem>();
            system = this.AddSystem<LevelSystem>();
            system = this.AddSystem<LoginSystem>();
            system = this.AddSystem<TeliporterPlateSystem>();
            system = this.AddSystem<PlayerSystem>();
            system = this.AddSystem<LoginUISystem>();
            system = this.AddSystem<GameSystem>();
            system = this.AddSystem<PlateSystem>();
            system = this.AddSystem<PlayfabLoginSystem>();
            system = this.AddSystem<SwitchPlateSystem>();
            system = this.AddSystem<GenericWidgetsSystem>();
            system = this.AddSystem<LeaderboardUISystem>();
            system = this.AddSystem<SoundSystem>();
            system = this.AddSystem<DialogUISystem>();
            system = this.AddSystem<RollerSystem>();
            system = this.AddSystem<LevelManagementSystem>();
            system = this.AddSystem<IntroSceneSystem>();
            system = this.AddSystem<FlipCubeAudioSystem>();
            system = this.AddSystem<NotificationsUISystem>();
        }
    }
}
