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
    
    
    public partial class GameSystemBase : uFrame.ECS.EcsSystem {
        
        public override void Setup() {
            base.Setup();
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("91b142aa-3136-4d21-8166-e981490c4c39")]
    public partial class GameSystem : GameSystemBase {
        
        private static GameSystem _Instance;
        
        public GameSystem() {
            Instance = this;
        }
        
        public static GameSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
