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
    using UnityEngine;
    using UnityEngine.UI;
    
    
    [uFrame.Attributes.EventId(3)]
    public partial class DialogAction : object {
        
        [UnityEngine.SerializeField()]
        private Action _Action;
        
        [UnityEngine.SerializeField()]
        private String _Title;
        
        public Action Action {
            get {
                return _Action;
            }
            set {
                _Action = value;
            }
        }
        
        public String Title {
            get {
                return _Title;
            }
            set {
                _Title = value;
            }
        }
    }
}
