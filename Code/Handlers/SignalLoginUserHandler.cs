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
    
    
    public class SignalLoginUserHandler {
        
        public LoginButton Source;
        
        private uFrame.ECS.PointerClickDispatcher _Event;
        
        private uFrame.ECS.EcsSystem _System;
        
        private FlipCube.LoginUser PublishEventNode2_Result = default( FlipCube.LoginUser );
        
        public uFrame.ECS.PointerClickDispatcher Event {
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
            // PublishEventNode
            while (this.DebugInfo("34ea86ee-d4f9-4357-a969-0c250558d78d","3d74489c-0b8d-47b4-ae76-1bc8e0fe19aa", this) == 1) yield return null;
            var PublishEventNode2_Event = new LoginUser();
            PublishEventNode2_Event.Email = Source.LoginUI.Username.text;
            PublishEventNode2_Event.Password = Source.LoginUI.Password.text;
            System.Publish(PublishEventNode2_Event);
            PublishEventNode2_Result = PublishEventNode2_Event;
            yield break;
        }
    }
}
