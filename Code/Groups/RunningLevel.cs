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
    
    
    [uFrame.Attributes.ComponentId(3)]
    public partial class RunningLevel : uFrame.ECS.GroupItem {
        
        private LevelData _LevelData;
        
        private SceneInstance _SceneInstance;
        
        public LevelData LevelData {
            get {
                return _LevelData;
            }
            set {
                _LevelData = value;
            }
        }
        
        public SceneInstance SceneInstance {
            get {
                return _SceneInstance;
            }
            set {
                _SceneInstance = value;
            }
        }
        
        public override int ComponentId {
            get {
                return 3;
            }
        }
    }
}
