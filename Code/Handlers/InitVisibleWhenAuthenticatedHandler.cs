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
    
    
    public class InitVisibleWhenAuthenticated {
        
        public VisibleWhenAuthenticated Group;
        
        private VisibleWhenAuthenticated _Event;
        
        private uFrame.ECS.EcsSystem _System;
        
        public VisibleWhenAuthenticated Event {
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
            // SetVariableNode
            Group.Entity.gameObject.active = (System.Boolean)System.BlackBoardSystem.Get<UserLoginInfo>().IsLoggedIn;
        }
    }
}
