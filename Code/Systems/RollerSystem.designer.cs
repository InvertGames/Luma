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
    
    
    public partial class RollerSystemBase : uFrame.ECS.EcsSystem, uFrame.ECS.ISystemUpdate {
        
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
            this.OnEvent<FlipCube.MoveForward>().Subscribe(_=>{ RollForwardFilter(_); }).DisposeWith(this);
            RollerManager.CreatedObservable.Subscribe(RollerCreatedFilter).DisposeWith(this);
            this.OnEvent<FlipCube.MoveRight>().Subscribe(_=>{ RollRightFilter(_); }).DisposeWith(this);
            this.OnEvent<FlipCube.MoveLeft>().Subscribe(_=>{ RollLeftFilter(_); }).DisposeWith(this);
            this.OnEvent<FlipCube.MoveBackward>().Subscribe(_=>{ RollBackFilter(_); }).DisposeWith(this);
            this.OnEvent<FlipCube.MoveRoller>().Subscribe(_=>{ OnMoveRollerFilter(_); }).DisposeWith(this);
        }
        
        protected virtual void RollForwardHandler(FlipCube.MoveForward data, Roller player) {
        }
        
        protected void RollForwardFilter(FlipCube.MoveForward data) {
            var PlayerRoller = RollerManager[data.Player];
            if (PlayerRoller == null) {
                return;
            }
            if (!PlayerRoller.Enabled) {
                return;
            }
            this.RollForwardHandler(data, PlayerRoller);
        }
        
        protected virtual void RollerCreated(Roller data, Roller group) {
            var handler = new RollerCreated();
            handler.System = this;
            handler.Event = data;
            handler.Group = group;
            handler.Execute();
        }
        
        protected void RollerCreatedFilter(Roller data) {
            var GroupRoller = RollerManager[data.EntityId];
            if (GroupRoller == null) {
                return;
            }
            if (!GroupRoller.Enabled) {
                return;
            }
            this.RollerCreated(data, GroupRoller);
        }
        
        protected virtual void CalculatePositionsHandler(Roller group) {
            var handler = new CalculatePositionsHandler();
            handler.System = this;
            handler.Group = group;
            handler.Execute();
        }
        
        protected void CalculatePositionsFilter() {
            var RollerItems = RollerManager.Components;
            for (var RollerIndex = 0
            ; RollerIndex < RollerItems.Count; RollerIndex++
            ) {
                if (!RollerItems[RollerIndex].Enabled) {
                    continue;
                }
                this.CalculatePositionsHandler(RollerItems[RollerIndex]);
            }
        }
        
        public virtual void SystemUpdate() {
            CalculatePositionsFilter();
        }
        
        protected virtual void RollRightHandler(FlipCube.MoveRight data, Roller player) {
        }
        
        protected void RollRightFilter(FlipCube.MoveRight data) {
            var PlayerRoller = RollerManager[data.Player];
            if (PlayerRoller == null) {
                return;
            }
            if (!PlayerRoller.Enabled) {
                return;
            }
            this.RollRightHandler(data, PlayerRoller);
        }
        
        protected virtual void RollLeftHandler(FlipCube.MoveLeft data, Roller player) {
        }
        
        protected void RollLeftFilter(FlipCube.MoveLeft data) {
            var PlayerRoller = RollerManager[data.Player];
            if (PlayerRoller == null) {
                return;
            }
            if (!PlayerRoller.Enabled) {
                return;
            }
            this.RollLeftHandler(data, PlayerRoller);
        }
        
        protected virtual void RollBackHandler(FlipCube.MoveBackward data, Roller player) {
        }
        
        protected void RollBackFilter(FlipCube.MoveBackward data) {
            var PlayerRoller = RollerManager[data.Player];
            if (PlayerRoller == null) {
                return;
            }
            if (!PlayerRoller.Enabled) {
                return;
            }
            this.RollBackHandler(data, PlayerRoller);
        }
        
        protected virtual void OnMoveRollerHandler(FlipCube.MoveRoller data, Roller roller) {
            var handler = new OnMoveRollerHandler();
            handler.System = this;
            handler.Event = data;
            handler.Roller = roller;
            handler.Execute();
        }
        
        protected void OnMoveRollerFilter(FlipCube.MoveRoller data) {
            var RollerRoller = RollerManager[data.Roller];
            if (RollerRoller == null) {
                return;
            }
            if (!RollerRoller.Enabled) {
                return;
            }
            this.OnMoveRollerHandler(data, RollerRoller);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("b6c685ea-2bbe-4ade-89dc-52a8248d832d")]
    public partial class RollerSystem : RollerSystemBase {
        
        private static RollerSystem _Instance;
        
        public RollerSystem() {
            Instance = this;
        }
        
        public static RollerSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
