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
    using FlipCube;
    using uFrame.Kernel;
    using uFrame.ECS;
    using UniRx;
    
    
    public partial class PlayerInputSystemBase : uFrame.ECS.EcsSystem, uFrame.ECS.ISystemUpdate {
        
        private IEcsComponentManagerOf<KeyboardPlayerInput> _KeyboardPlayerInputManager;
        
        public IEcsComponentManagerOf<KeyboardPlayerInput> KeyboardPlayerInputManager {
            get {
                return _KeyboardPlayerInputManager;
            }
            set {
                _KeyboardPlayerInputManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            KeyboardPlayerInputManager = ComponentSystem.RegisterComponent<KeyboardPlayerInput>(39);
        }
        
        protected virtual void PCPlayerInputSystemUpdateHandler(KeyboardPlayerInput group) {
        }
        
        protected void PCPlayerInputSystemUpdateFilter() {
            var KeyboardPlayerInputItems = KeyboardPlayerInputManager.Components;
            for (var KeyboardPlayerInputIndex = 0
            ; KeyboardPlayerInputIndex < KeyboardPlayerInputItems.Count; KeyboardPlayerInputIndex++
            ) {
                if (!KeyboardPlayerInputItems[KeyboardPlayerInputIndex].Enabled) {
                    continue;
                }
                this.PCPlayerInputSystemUpdateHandler(KeyboardPlayerInputItems[KeyboardPlayerInputIndex]);
            }
        }
        
        public virtual void SystemUpdate() {
            PCPlayerInputSystemUpdateFilter();
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("38802edd-bb9d-4b09-b27e-64fe6c585185")]
    public partial class PlayerInputSystem : PlayerInputSystemBase {
        
        private static PlayerInputSystem _Instance;
        
        public PlayerInputSystem() {
            Instance = this;
        }
        
        public static PlayerInputSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
