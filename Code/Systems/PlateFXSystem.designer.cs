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
    using UniRx;
    
    
    public partial class PlateFXSystemBase : uFrame.ECS.EcsSystem {
        
        public override void Setup() {
            base.Setup();
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("3c42c6ae-9e23-400b-9f3d-ad73a7e1cd32")]
    public partial class PlateFXSystem : PlateFXSystemBase {
        
        private static PlateFXSystem _Instance;
        
        public PlateFXSystem() {
            Instance = this;
        }
        
        public static PlateFXSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
