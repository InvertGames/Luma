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
    
    
    [uFrame.Attributes.uFrameIdentifier("3121d596-0f19-44fe-b228-ce7fa279b1ca")]
    public partial class NotificationSystemLoader : uFrame.Kernel.SystemLoader {
        
        public override void Load() {
            this.AddSystem<NotificationSystem>();
        }
    }
}
