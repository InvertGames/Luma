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
    using UnityEngine;
    
    
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
        
        public virtual System.Collections.IEnumerator Execute() {
            // SetVariableNode
            while (this.DebugInfo("c207438a-42cd-490a-954f-26e996667e27","f6399b8b-7316-403d-a45d-7cdfced45c42", this) == 1) yield return null;
            Group.Entity.gameObject.active = (System.Boolean)System.BlackBoardSystem.Get<UserLoginInfo>().IsLoggedIn;
            yield break;
        }
    }
}
