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
    
    
    [uFrame.Attributes.uFrameIdentifier("cb99a24a-5702-4984-b147-63e83040489e")]
    public partial class ZoneManagementSystemLoader : uFrame.Kernel.SystemLoader {
        
        public override void Load() {
            this.AddSystem<ZoneManagementSystem>();
        }
    }
}
