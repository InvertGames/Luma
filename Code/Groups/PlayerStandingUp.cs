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
    using UniRx;
    using uFrame.ECS;
    using uFrame.Kernel;
    
    
    [uFrame.Attributes.ComponentId(43)]
    public partial class PlayerStandingUp : uFrame.ECS.GroupItem {
        
        private Roller _Roller;
        
        private Player _Player;
        
        public Roller Roller {
            get {
                return _Roller;
            }
            set {
                _Roller = value;
            }
        }
        
        public Player Player {
            get {
                return _Player;
            }
            set {
                _Player = value;
            }
        }
        
        public override int ComponentId {
            get {
                return 43;
            }
        }
    }
}
