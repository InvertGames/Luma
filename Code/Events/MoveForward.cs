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
    
    
    [uFrame.Attributes.EventId(9)]
    public partial class MoveForward : object {
        
        [UnityEngine.SerializeField()]
        private Int32 _Player;
        
        public Int32 Player {
            get {
                return _Player;
            }
            set {
                _Player = value;
            }
        }
    }
}
