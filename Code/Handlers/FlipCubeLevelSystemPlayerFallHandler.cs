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
    using UnityEngine;
    
    
    public class FlipCubeLevelSystemPlayerFallHandler {
        
        public Player Player;
        
        private FlipCube.PlayerFall _Event;
        
        private uFrame.ECS.EcsSystem _System;
        
        private FlipCube.LevelFailed PublishEventNode2_Result = default( FlipCube.LevelFailed );
        
        public FlipCube.PlayerFall Event {
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
            while (this.DebugInfo("4d9e2402-2c29-4ef4-a013-1dca4d91048f","c207438a-42cd-490a-954f-26e996667e27", this) == 1) yield return null;
            var PublishEventNode2_Event = new LevelFailed();
            System.Publish(PublishEventNode2_Event);
            PublishEventNode2_Result = PublishEventNode2_Event;
            yield break;
        }
    }
}
