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
    
    
    public partial class LevelSystemBase : uFrame.ECS.EcsSystem {
        
        public override void Setup() {
            base.Setup();
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("70c1e8e1-b393-4e57-862c-4c81509c1bc0")]
    public partial class LevelSystem : LevelSystemBase {
        
        private static LevelSystem _Instance;
        
        public LevelSystem() {
            Instance = this;
        }
        
        public static LevelSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
