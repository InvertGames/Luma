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
    using UnityEngine;
    using uFrame.Kernel;
    
    
    public class ShowLoginScreenHandler {
        
        private FlipCube.UserLoggedOut _Event;
        
        private uFrame.ECS.EcsSystem _System;
        
        private FlipCube.LoginUI LoopGroupNode10_Item = default( FlipCube.LoginUI );
        
        private FlipCube.VisibleWhenAuthenticated LoopGroupNode28_Item = default( FlipCube.VisibleWhenAuthenticated );
        
        private UnityEngine.GameObject ActionNode30_gameObject = default( UnityEngine.GameObject );
        
        private UnityEngine.MonoBehaviour ActionNode30_behaviour = default( UnityEngine.MonoBehaviour );
        
        private FlipCube.VisibleWhenNotAuthenticated LoopGroupNode29_Item = default( FlipCube.VisibleWhenNotAuthenticated );
        
        private UnityEngine.GameObject ActionNode31_gameObject = default( UnityEngine.GameObject );
        
        private UnityEngine.MonoBehaviour ActionNode31_behaviour = default( UnityEngine.MonoBehaviour );
        
        public FlipCube.UserLoggedOut Event {
            get {
                return _Event;
            }
            set {
                _Event = value;
            }
        }
        
        public uFrame.ECS.EcsSystem System {
            get {
                return _System;
            }
            set {
                _System = value;
            }
        }
        
        public virtual void Execute() {
            // LoopGroupNode
            var LoopGroupNode10_GroupComponents = System.ComponentSystem.RegisterComponent<FlipCube.LoginUI>().Components;
            for (var LoopGroupNode10_ItemIndex = 0
            ; LoopGroupNode10_ItemIndex < LoopGroupNode10_GroupComponents.Count; LoopGroupNode10_ItemIndex++
            ) {
                LoopGroupNode10_Item = LoopGroupNode10_GroupComponents[LoopGroupNode10_ItemIndex];
                LoopGroupNode10_Next();
            }
            // LoopGroupNode
            var LoopGroupNode28_GroupComponents = System.ComponentSystem.RegisterComponent<FlipCube.VisibleWhenAuthenticated>().Components;
            for (var LoopGroupNode28_ItemIndex = 0
            ; LoopGroupNode28_ItemIndex < LoopGroupNode28_GroupComponents.Count; LoopGroupNode28_ItemIndex++
            ) {
                LoopGroupNode28_Item = LoopGroupNode28_GroupComponents[LoopGroupNode28_ItemIndex];
                LoopGroupNode28_Next();
            }
            // LoopGroupNode
            var LoopGroupNode29_GroupComponents = System.ComponentSystem.RegisterComponent<FlipCube.VisibleWhenNotAuthenticated>().Components;
            for (var LoopGroupNode29_ItemIndex = 0
            ; LoopGroupNode29_ItemIndex < LoopGroupNode29_GroupComponents.Count; LoopGroupNode29_ItemIndex++
            ) {
                LoopGroupNode29_Item = LoopGroupNode29_GroupComponents[LoopGroupNode29_ItemIndex];
                LoopGroupNode29_Next();
            }
        }
        
        private void LoopGroupNode10_Next() {
        }
        
        private void LoopGroupNode28_Next() {
            ActionNode30_behaviour = LoopGroupNode28_Item;
            // ActionNode
            // Visit uFrame.Actions.GameObjects.DeactiateGameObject
            uFrame.Actions.GameObjects.DeactiateGameObject(ActionNode30_gameObject, ActionNode30_behaviour);
        }
        
        private void LoopGroupNode29_Next() {
            ActionNode31_behaviour = LoopGroupNode29_Item;
            // ActionNode
            // Visit uFrame.Actions.GameObjects.ActivateGameObject
            uFrame.Actions.GameObjects.ActivateGameObject(ActionNode31_gameObject, ActionNode31_behaviour);
        }
    }
}
