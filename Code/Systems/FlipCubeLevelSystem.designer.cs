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
    using UniRx;
    using FlipCube;
    
    
    public partial class FlipCubeLevelSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<Player> _PlayerManager;
        
        public IEcsComponentManagerOf<Player> PlayerManager {
            get {
                return _PlayerManager;
            }
            set {
                _PlayerManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            PlayerManager = ComponentSystem.RegisterComponent<Player>(26);
            this.OnEvent<FlipCube.LevelFailed>().Subscribe(_=>{ FlipCubeLevelSystemLevelFailedFilter(_); }).DisposeWith(this);
            this.OnEvent<FlipCube.PlayerFall>().Subscribe(_=>{ FlipCubeLevelSystemPlayerFallFilter(_); }).DisposeWith(this);
        }
        
        protected virtual void FlipCubeLevelSystemLevelFailedHandler(FlipCube.LevelFailed data) {
            var handler = new FlipCubeLevelSystemLevelFailedHandler();
            handler.System = this;
            handler.Event = data;
            StartCoroutine(handler.Execute());
        }
        
        protected void FlipCubeLevelSystemLevelFailedFilter(FlipCube.LevelFailed data) {
            this.FlipCubeLevelSystemLevelFailedHandler(data);
        }
        
        protected virtual void FlipCubeLevelSystemPlayerFallHandler(FlipCube.PlayerFall data, Player player) {
            var handler = new FlipCubeLevelSystemPlayerFallHandler();
            handler.System = this;
            handler.Event = data;
            handler.Player = player;
            StartCoroutine(handler.Execute());
        }
        
        protected void FlipCubeLevelSystemPlayerFallFilter(FlipCube.PlayerFall data) {
            var PlayerPlayer = PlayerManager[data.Player];
            if (PlayerPlayer == null) {
                return;
            }
            if (!PlayerPlayer.Enabled) {
                return;
            }
            this.FlipCubeLevelSystemPlayerFallHandler(data, PlayerPlayer);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("47355a56-6c9b-473b-8129-c4db0d49c157")]
    public partial class FlipCubeLevelSystem : FlipCubeLevelSystemBase {
        
        private static FlipCubeLevelSystem _Instance;
        
        [UnityEngine.SerializeField()]
        private Int32 _LevelResetTime;
        
        public FlipCubeLevelSystem() {
            Instance = this;
        }
        
        public static FlipCubeLevelSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
        
        public Int32 LevelResetTime {
            get {
                return _LevelResetTime;
            }
            set {
                _LevelResetTime = value;
            }
        }
    }
}
