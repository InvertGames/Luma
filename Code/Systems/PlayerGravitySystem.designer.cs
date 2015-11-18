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
    using UnityEngine;
    
    
    public partial class PlayerGravitySystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<Roller> _RollerManager;
        
        public IEcsComponentManagerOf<Roller> RollerManager {
            get {
                return _RollerManager;
            }
            set {
                _RollerManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            RollerManager = ComponentSystem.RegisterComponent<Roller>(38);
            this.OnEvent<FlipCube.RollComplete>().Subscribe(_=>{ HandleGravityFilter(_); }).DisposeWith(this);
        }
        
        protected virtual void HandleGravityHandler(FlipCube.RollComplete data, Roller player) {
            var handler = new HandleGravityHandler();
            handler.System = this;
            handler.Event = data;
            handler.Player = player;
            StartCoroutine(handler.Execute());
        }
        
        protected void HandleGravityFilter(FlipCube.RollComplete data) {
            var PlayerRoller = RollerManager[data.Player];
            if (PlayerRoller == null) {
                return;
            }
            if (!PlayerRoller.Enabled) {
                return;
            }
            this.HandleGravityHandler(data, PlayerRoller);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("452cade3-b480-44de-b6c4-ed87ce6e3e65")]
    public partial class PlayerGravitySystem : PlayerGravitySystemBase {
        
        private static PlayerGravitySystem _Instance;
        
        public PlayerGravitySystem() {
            Instance = this;
        }
        
        public static PlayerGravitySystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
