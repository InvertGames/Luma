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
    using FlipCube;
    using UniRx;
    
    
    public partial class GameUISystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<GameUI> _GameUIManager;
        
        public IEcsComponentManagerOf<GameUI> GameUIManager {
            get {
                return _GameUIManager;
            }
            set {
                _GameUIManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            GameUIManager = ComponentSystem.RegisterComponent<GameUI>(36);
            this.PropertyChangedEvent<GameUI,FlipCube.GeneralGameUIState>(Group=>Group.GeneralStateObservable, NewPropertyChangedNodeFilter, Group=>Group.GeneralState, false);
        }
        
        protected virtual void NewPropertyChangedNode(GameUI data, GameUI group, PropertyChangedEvent<FlipCube.GeneralGameUIState> value) {
        }
        
        protected void NewPropertyChangedNodeFilter(GameUI data, PropertyChangedEvent<FlipCube.GeneralGameUIState> value) {
            var GroupGameUI = GameUIManager[data.EntityId];
            if (GroupGameUI == null) {
                return;
            }
            if (!GroupGameUI.Enabled) {
                return;
            }
            this.NewPropertyChangedNode(data, GroupGameUI, value);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("85755047-a8f3-4b39-969f-33418b35f799")]
    public partial class GameUISystem : GameUISystemBase {
        
        private static GameUISystem _Instance;
        
        public GameUISystem() {
            Instance = this;
        }
        
        public static GameUISystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
