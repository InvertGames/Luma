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
    using uFrame.Kernel;
    using UniRx;
    
    
    public partial class LoginUISystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<VisibleWhenNotAuthenticated> _VisibleWhenNotAuthenticatedManager;
        
        private IEcsComponentManagerOf<VisibleWhenAuthenticated> _VisibleWhenAuthenticatedManager;
        
        private IEcsComponentManagerOf<LoginButton> _LoginButtonManager;
        
        private IEcsComponentManagerOf<LoginLoadingUI> _LoginLoadingUIManager;
        
        private IEcsComponentManagerOf<LoginUI> _LoginUIManager;
        
        public IEcsComponentManagerOf<VisibleWhenNotAuthenticated> VisibleWhenNotAuthenticatedManager {
            get {
                return _VisibleWhenNotAuthenticatedManager;
            }
            set {
                _VisibleWhenNotAuthenticatedManager = value;
            }
        }
        
        public IEcsComponentManagerOf<VisibleWhenAuthenticated> VisibleWhenAuthenticatedManager {
            get {
                return _VisibleWhenAuthenticatedManager;
            }
            set {
                _VisibleWhenAuthenticatedManager = value;
            }
        }
        
        public IEcsComponentManagerOf<LoginButton> LoginButtonManager {
            get {
                return _LoginButtonManager;
            }
            set {
                _LoginButtonManager = value;
            }
        }
        
        public IEcsComponentManagerOf<LoginLoadingUI> LoginLoadingUIManager {
            get {
                return _LoginLoadingUIManager;
            }
            set {
                _LoginLoadingUIManager = value;
            }
        }
        
        public IEcsComponentManagerOf<LoginUI> LoginUIManager {
            get {
                return _LoginUIManager;
            }
            set {
                _LoginUIManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            VisibleWhenNotAuthenticatedManager = ComponentSystem.RegisterComponent<VisibleWhenNotAuthenticated>(7);
            VisibleWhenAuthenticatedManager = ComponentSystem.RegisterComponent<VisibleWhenAuthenticated>(6);
            LoginButtonManager = ComponentSystem.RegisterComponent<LoginButton>(2);
            LoginLoadingUIManager = ComponentSystem.RegisterComponent<LoginLoadingUI>(5);
            LoginUIManager = ComponentSystem.RegisterComponent<LoginUI>(1);
            this.OnEvent<FlipCube.UserLoggedOut>().Subscribe(_=>{ ShowLoginScreenFilter(_); }).DisposeWith(this);
            VisibleWhenNotAuthenticatedManager.CreatedObservable.Subscribe(InitVisibleWhenNotAuthenticatedFilter).DisposeWith(this);
            this.OnEvent<FlipCube.UserLoggedIn>().Subscribe(_=>{ HideLoadingUIFilter(_); }).DisposeWith(this);
            VisibleWhenAuthenticatedManager.CreatedObservable.Subscribe(InitVisibleWhenAuthenticatedFilter).DisposeWith(this);
            this.OnEvent<FlipCube.LoginUser>().Subscribe(_=>{ LoginUISystemLoginUserFilter(_); }).DisposeWith(this);
            this.OnEvent<uFrame.ECS.PointerClickDispatcher>().Subscribe(_=>{ SignalLoginUserFilter(_); }).DisposeWith(this);
            this.OnEvent<FlipCube.UserLoggedIn>().Subscribe(_=>{ LoginUISystemUserLoggedInFilter(_); }).DisposeWith(this);
        }
        
        protected virtual void ShowLoginScreenHandler(FlipCube.UserLoggedOut data) {
            var handler = new ShowLoginScreenHandler();
            handler.System = this;
            handler.Event = data;
            StartCoroutine(handler.Execute());
        }
        
        protected void ShowLoginScreenFilter(FlipCube.UserLoggedOut data) {
            this.ShowLoginScreenHandler(data);
        }
        
        protected virtual void InitVisibleWhenNotAuthenticated(VisibleWhenNotAuthenticated data, VisibleWhenNotAuthenticated group) {
            var handler = new InitVisibleWhenNotAuthenticated();
            handler.System = this;
            handler.Event = data;
            handler.Group = group;
            StartCoroutine(handler.Execute());
        }
        
        protected void InitVisibleWhenNotAuthenticatedFilter(VisibleWhenNotAuthenticated data) {
            var GroupVisibleWhenNotAuthenticated = VisibleWhenNotAuthenticatedManager[data.EntityId];
            if (GroupVisibleWhenNotAuthenticated == null) {
                return;
            }
            if (!GroupVisibleWhenNotAuthenticated.Enabled) {
                return;
            }
            this.InitVisibleWhenNotAuthenticated(data, GroupVisibleWhenNotAuthenticated);
        }
        
        protected virtual void HideLoadingUIHandler(FlipCube.UserLoggedIn data) {
            var handler = new HideLoadingUIHandler();
            handler.System = this;
            handler.Event = data;
            StartCoroutine(handler.Execute());
        }
        
        protected void HideLoadingUIFilter(FlipCube.UserLoggedIn data) {
            this.HideLoadingUIHandler(data);
        }
        
        protected virtual void InitVisibleWhenAuthenticated(VisibleWhenAuthenticated data, VisibleWhenAuthenticated group) {
            var handler = new InitVisibleWhenAuthenticated();
            handler.System = this;
            handler.Event = data;
            handler.Group = group;
            StartCoroutine(handler.Execute());
        }
        
        protected void InitVisibleWhenAuthenticatedFilter(VisibleWhenAuthenticated data) {
            var GroupVisibleWhenAuthenticated = VisibleWhenAuthenticatedManager[data.EntityId];
            if (GroupVisibleWhenAuthenticated == null) {
                return;
            }
            if (!GroupVisibleWhenAuthenticated.Enabled) {
                return;
            }
            this.InitVisibleWhenAuthenticated(data, GroupVisibleWhenAuthenticated);
        }
        
        protected virtual void LoginUISystemLoginUserHandler(FlipCube.LoginUser data) {
            var handler = new LoginUISystemLoginUserHandler();
            handler.System = this;
            handler.Event = data;
            StartCoroutine(handler.Execute());
        }
        
        protected void LoginUISystemLoginUserFilter(FlipCube.LoginUser data) {
            this.LoginUISystemLoginUserHandler(data);
        }
        
        protected virtual void SignalLoginUserHandler(uFrame.ECS.PointerClickDispatcher data, LoginButton source) {
            var handler = new SignalLoginUserHandler();
            handler.System = this;
            handler.Event = data;
            handler.Source = source;
            StartCoroutine(handler.Execute());
        }
        
        protected void SignalLoginUserFilter(uFrame.ECS.PointerClickDispatcher data) {
            var SourceLoginButton = LoginButtonManager[data.EntityId];
            if (SourceLoginButton == null) {
                return;
            }
            if (!SourceLoginButton.Enabled) {
                return;
            }
            this.SignalLoginUserHandler(data, SourceLoginButton);
        }
        
        protected virtual void LoginUISystemUserLoggedInHandler(FlipCube.UserLoggedIn data) {
            var handler = new LoginUISystemUserLoggedInHandler();
            handler.System = this;
            handler.Event = data;
            StartCoroutine(handler.Execute());
        }
        
        protected void LoginUISystemUserLoggedInFilter(FlipCube.UserLoggedIn data) {
            this.LoginUISystemUserLoggedInHandler(data);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("8aa8af15-7cca-4f1a-84da-3000a61ea708")]
    public partial class LoginUISystem : LoginUISystemBase {
        
        private static LoginUISystem _Instance;
        
        public LoginUISystem() {
            Instance = this;
        }
        
        public static LoginUISystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
