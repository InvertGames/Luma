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
    using UniRx;
    using uFrame.ECS;
    
    
    public partial class PlayerCubeSystemBase : uFrame.ECS.EcsSystem {
        
        public override void Setup() {
            base.Setup();
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("709f6260-be60-481a-966d-52a3e871859d")]
    public partial class PlayerCubeSystem : PlayerCubeSystemBase {
        
        private static PlayerCubeSystem _Instance;
        
        public PlayerCubeSystem() {
            Instance = this;
        }
        
        public static PlayerCubeSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
