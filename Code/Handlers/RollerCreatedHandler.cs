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
    
    
    public class RollerCreated {
        
        public Roller Group;
        
        private Roller _Event;
        
        private uFrame.ECS.EcsSystem _System;
        
        public Roller Event {
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
            yield break;
        }
    }
}
