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
    
    
    [uFrame.Attributes.uFrameIdentifier("452cade3-b480-44de-b6c4-ed87ce6e3e65")]
    public partial class PlayerGravitySystemLoader : uFrame.Kernel.SystemLoader {
        
        public override void Load() {
            this.AddSystem<PlayerGravitySystem>();
        }
    }
}
