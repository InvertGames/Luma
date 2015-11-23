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
    using UnityEngine;
    
    
    public partial class LoginSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<UserLoginInfo> _UserLoginInfoManager;
        
        public IEcsComponentManagerOf<UserLoginInfo> UserLoginInfoManager {
            get {
                return _UserLoginInfoManager;
            }
            set {
                _UserLoginInfoManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            UserLoginInfoManager = ComponentSystem.RegisterComponent<UserLoginInfo>(23);
            this.OnEvent<FlipCube.UserLoggedIn>().Subscribe(_=>{ LoginSystemUserLoggedInFilter(_); }).DisposeWith(this);
            this.OnEvent<FlipCube.UserLoggedOut>().Subscribe(_=>{ LoginSystemUserLoggedOutFilter(_); }).DisposeWith(this);
        }
        
        protected virtual void LoginSystemUserLoggedInHandler(FlipCube.UserLoggedIn data) {
            var handler = new LoginSystemUserLoggedInHandler();
            handler.System = this;
            handler.Event = data;
            handler.Execute();
        }
        
        protected void LoginSystemUserLoggedInFilter(FlipCube.UserLoggedIn data) {
            this.LoginSystemUserLoggedInHandler(data);
        }
        
        protected virtual void LoginSystemUserLoggedOutHandler(FlipCube.UserLoggedOut data) {
            var handler = new LoginSystemUserLoggedOutHandler();
            handler.System = this;
            handler.Event = data;
            handler.Execute();
        }
        
        protected void LoginSystemUserLoggedOutFilter(FlipCube.UserLoggedOut data) {
            this.LoginSystemUserLoggedOutHandler(data);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("7949f3d4-8291-45ff-90b4-94b73f5c4198")]
    public partial class LoginSystem : LoginSystemBase {
        
        private static LoginSystem _Instance;
        
        public LoginSystem() {
            Instance = this;
        }
        
        public static LoginSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
