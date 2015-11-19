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
    
    
    public partial class TeliporterPlateSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<PlayerRoller> _PlayerRollerManager;
        
        private IEcsComponentManagerOf<TeliporterPlate> _TeliporterPlateManager;
        
        public IEcsComponentManagerOf<PlayerRoller> PlayerRollerManager {
            get {
                return _PlayerRollerManager;
            }
            set {
                _PlayerRollerManager = value;
            }
        }
        
        public IEcsComponentManagerOf<TeliporterPlate> TeliporterPlateManager {
            get {
                return _TeliporterPlateManager;
            }
            set {
                _TeliporterPlateManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            PlayerRollerManager = ComponentSystem.RegisterGroup<PlayerRollerGroup,PlayerRoller>();
            TeliporterPlateManager = ComponentSystem.RegisterComponent<TeliporterPlate>(44);
            this.OnEvent<FlipCube.RollCompleteStandingUp>().Subscribe(_=>{ TeliporterPlateSystemRollCompleteStandingUpFilter(_); }).DisposeWith(this);
        }
        
        protected virtual void TeliporterPlateSystemRollCompleteStandingUpHandler(FlipCube.RollCompleteStandingUp data, PlayerRoller player, TeliporterPlate plate) {
            var handler = new TeliporterPlateSystemRollCompleteStandingUpHandler();
            handler.System = this;
            handler.Event = data;
            handler.Player = player;
            handler.Plate = plate;
            handler.Execute();
        }
        
        protected void TeliporterPlateSystemRollCompleteStandingUpFilter(FlipCube.RollCompleteStandingUp data) {
            var PlayerItem = PlayerRollerManager[data.Player];
            if (PlayerItem == null) {
                return;
            }
            if (!PlayerItem.Enabled) {
                return;
            }
            var PlateTeliporterPlate = TeliporterPlateManager[data.Plate];
            if (PlateTeliporterPlate == null) {
                return;
            }
            if (!PlateTeliporterPlate.Enabled) {
                return;
            }
            this.TeliporterPlateSystemRollCompleteStandingUpHandler(data, PlayerItem, PlateTeliporterPlate);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("818f0299-3952-4f02-9719-65ad55e74b39")]
    public partial class TeliporterPlateSystem : TeliporterPlateSystemBase {
        
        private static TeliporterPlateSystem _Instance;
        
        public TeliporterPlateSystem() {
            Instance = this;
        }
        
        public static TeliporterPlateSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
