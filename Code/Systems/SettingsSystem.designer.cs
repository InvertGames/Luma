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
    
    
    public partial class SettingsSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<ITitleData> _TitleDataManager;
        
        public IEcsComponentManagerOf<ITitleData> TitleDataManager {
            get {
                return _TitleDataManager;
            }
            set {
                _TitleDataManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            TitleDataManager = ComponentSystem.RegisterGroup<TitleDataGroup,ITitleData>();
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("25b07286-0648-44b5-a3af-5101bbc69ec6")]
    public partial class SettingsSystem : SettingsSystemBase {
        
        private static SettingsSystem _Instance;
        
        public SettingsSystem() {
            Instance = this;
        }
        
        public static SettingsSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
