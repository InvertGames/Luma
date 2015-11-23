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
    using FlipCube;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using uFrame.Kernel;
    using UniRx;
    using UnityEngine;
    
    
    public partial class DisolvePlateSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<Roller> _RollerManager;
        
        private IEcsComponentManagerOf<DissolvePlate> _DissolvePlateManager;
        
        public IEcsComponentManagerOf<Roller> RollerManager {
            get {
                return _RollerManager;
            }
            set {
                _RollerManager = value;
            }
        }
        
        public IEcsComponentManagerOf<DissolvePlate> DissolvePlateManager {
            get {
                return _DissolvePlateManager;
            }
            set {
                _DissolvePlateManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            RollerManager = ComponentSystem.RegisterComponent<Roller>(38);
            DissolvePlateManager = ComponentSystem.RegisterComponent<DissolvePlate>(47);
            this.OnEvent<FlipCube.PlayerLeftPlate>().Subscribe(_=>{ DissolvePlateExitFilter(_); }).DisposeWith(this);
            this.OnEvent<FlipCube.LevelReset>().Subscribe(_=>{ ResetDissolvePlateFilter(_); }).DisposeWith(this);
        }
        
        protected virtual void DissolvePlateExitHandler(FlipCube.PlayerLeftPlate data, Roller player, DissolvePlate plate) {
        }
        
        protected void DissolvePlateExitFilter(FlipCube.PlayerLeftPlate data) {
            var PlayerRoller = RollerManager[data.Player];
            if (PlayerRoller == null) {
                return;
            }
            if (!PlayerRoller.Enabled) {
                return;
            }
            var PlateDissolvePlate = DissolvePlateManager[data.Plate];
            if (PlateDissolvePlate == null) {
                return;
            }
            if (!PlateDissolvePlate.Enabled) {
                return;
            }
            this.DissolvePlateExitHandler(data, PlayerRoller, PlateDissolvePlate);
        }
        
        protected virtual void ResetDissolvePlateHandler(FlipCube.LevelReset data, DissolvePlate group) {
            var handler = new ResetDissolvePlateHandler();
            handler.System = this;
            handler.Event = data;
            handler.Group = group;
            handler.Execute();
        }
        
        protected void ResetDissolvePlateFilter(FlipCube.LevelReset data) {
            var DissolvePlateItems = DissolvePlateManager.Components;
            for (var DissolvePlateIndex = 0
            ; DissolvePlateIndex < DissolvePlateItems.Count; DissolvePlateIndex++
            ) {
                if (!DissolvePlateItems[DissolvePlateIndex].Enabled) {
                    continue;
                }
                this.ResetDissolvePlateHandler(data, DissolvePlateItems[DissolvePlateIndex]);
            }
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("2b456eea-e9b1-43dc-ac48-031679160ce2")]
    public partial class DisolvePlateSystem : DisolvePlateSystemBase {
        
        private static DisolvePlateSystem _Instance;
        
        public DisolvePlateSystem() {
            Instance = this;
        }
        
        public static DisolvePlateSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
