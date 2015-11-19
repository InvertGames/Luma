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
    
    
    public partial class PlayfabLoginSystemBase : uFrame.ECS.EcsSystem {
        
        public override void Setup() {
            base.Setup();
            this.OnEvent<uFrame.Kernel.GameReadyEvent>().Subscribe(_=>{ LoginAsGuestFilter(_); }).DisposeWith(this);
            this.OnEvent<FlipCube.LoginUser>().Subscribe(_=>{ PlayfabLoginSystemLoginUserFilter(_); }).DisposeWith(this);
        }
        
        protected virtual void LoginAsGuestHandler(uFrame.Kernel.GameReadyEvent data) {
        }
        
        protected void LoginAsGuestFilter(uFrame.Kernel.GameReadyEvent data) {
            this.LoginAsGuestHandler(data);
        }
        
        protected virtual void PlayfabLoginSystemLoginUserHandler(FlipCube.LoginUser data) {
        }
        
        protected void PlayfabLoginSystemLoginUserFilter(FlipCube.LoginUser data) {
            this.PlayfabLoginSystemLoginUserHandler(data);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("94a7912a-21db-44c8-9d8a-6bdc8f686bca")]
    public partial class PlayfabLoginSystem : PlayfabLoginSystemBase {
        
        private static PlayfabLoginSystem _Instance;
        
        [UnityEngine.SerializeField()]
        private String _TitleId;
        
        public PlayfabLoginSystem() {
            Instance = this;
        }
        
        public static PlayfabLoginSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
        
        public String TitleId {
            get {
                return _TitleId;
            }
            set {
                _TitleId = value;
            }
        }
    }
}
