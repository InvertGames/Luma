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
    using Invert.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.ECS;
    using UniRx;
    using UnityEngine;
    
    
    [uFrame.Attributes.ComponentId(60)]
    [uFrame.Attributes.uFrameIdentifier("a6fe526c-1743-430b-9a0a-4ec6630a9dee")]
    public partial class Composite : uFrame.ECS.EcsComponent {
        
        [UnityEngine.SerializeField()]
        private UIWidget[] _Widgets;
        
        private ReactiveCollection<UIWidget> _WidgetsReactive;
        
        public override int ComponentId {
            get {
                return 60;
            }
        }
        
        public ReactiveCollection<UIWidget> Widgets {
            get {
                if (_WidgetsReactive == null) {
                    _WidgetsReactive = new ReactiveCollection<UIWidget>(_Widgets ?? new UIWidget[] { });
                }
                return _WidgetsReactive;
            }
        }
    }
}
