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
    
    
    public class DemoPlayerSystemPointerClickHandler {
        
        public ClickCount Source;
        
        private uFrame.ECS.MouseDownDispatcher _Event;
        
        private uFrame.ECS.EcsSystem _System;
        
        private int ActionNode4_a = default( System.Int32 );
        
        private int ActionNode4_Result = default( System.Int32 );
        
        public uFrame.ECS.MouseDownDispatcher Event {
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
            ActionNode4_a = Source.Count;
            // ActionNode
            while (this.DebugInfo("3d74489c-0b8d-47b4-ae76-1bc8e0fe19aa","26cfbe87-dea8-4796-91c7-7ad6ab9dce44", this) == 1) yield return null;
            // Visit uFrame.Actions.IntLibrary.Increment
            ActionNode4_Result = uFrame.Actions.IntLibrary.Increment(ActionNode4_a);
            // SetVariableNode
            while (this.DebugInfo("26cfbe87-dea8-4796-91c7-7ad6ab9dce44","0057f1bd-681a-42f7-9e54-a120a2924893", this) == 1) yield return null;
            Source.Count = (System.Int32)ActionNode4_Result;
            yield break;
        }
    }
}
