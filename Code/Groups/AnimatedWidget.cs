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
    
    
    [uFrame.Attributes.ComponentId(59)]
    public partial class AnimatedWidget : uFrame.ECS.GroupItem {
        
        private Animated _Animated;
        
        private UIWidget _UIWidget;
        
        public Animated Animated {
            get {
                return _Animated;
            }
            set {
                _Animated = value;
            }
        }
        
        public UIWidget UIWidget {
            get {
                return _UIWidget;
            }
            set {
                _UIWidget = value;
            }
        }
        
        public override int ComponentId {
            get {
                return 59;
            }
        }
    }
}
