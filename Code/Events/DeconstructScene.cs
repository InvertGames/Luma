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
    using FlipCube;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using UniRx;
    
    
    [uFrame.Attributes.EventId(33)]
    public partial class DeconstructScene : object {
        
        [UnityEngine.SerializeField()]
        private Boolean _DeconstructDependencies;
        
        [UnityEngine.SerializeField()]
        private Int32 _SceneInstance;
        
        public Boolean DeconstructDependencies {
            get {
                return _DeconstructDependencies;
            }
            set {
                _DeconstructDependencies = value;
            }
        }
        
        public Int32 SceneInstance {
            get {
                return _SceneInstance;
            }
            set {
                _SceneInstance = value;
            }
        }
    }
}
