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
    using uFrame.ECS;
    using UniRx;
    
    
    public partial class MainMenuSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<MainMenuUI> _MainMenuUIManager;
        
        public IEcsComponentManagerOf<MainMenuUI> MainMenuUIManager {
            get {
                return _MainMenuUIManager;
            }
            set {
                _MainMenuUIManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            MainMenuUIManager = ComponentSystem.RegisterComponent<MainMenuUI>(31);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("047a54f2-d8b8-43b3-9c59-a2cd3d7eb4dd")]
    public partial class MainMenuSystem : MainMenuSystemBase {
        
        private static MainMenuSystem _Instance;
        
        public MainMenuSystem() {
            Instance = this;
        }
        
        public static MainMenuSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
