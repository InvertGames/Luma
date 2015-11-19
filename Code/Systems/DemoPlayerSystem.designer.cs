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
    using UnityEngine.UI;
    using uFrame.Kernel;
    using FlipCube;
    using UniRx;
    
    
    public partial class DemoPlayerSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<ClickCount> _ClickCountManager;
        
        private IEcsComponentManagerOf<SaveGameButton> _SaveGameButtonManager;
        
        public IEcsComponentManagerOf<ClickCount> ClickCountManager {
            get {
                return _ClickCountManager;
            }
            set {
                _ClickCountManager = value;
            }
        }
        
        public IEcsComponentManagerOf<SaveGameButton> SaveGameButtonManager {
            get {
                return _SaveGameButtonManager;
            }
            set {
                _SaveGameButtonManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            ClickCountManager = ComponentSystem.RegisterComponent<ClickCount>(18);
            SaveGameButtonManager = ComponentSystem.RegisterComponent<SaveGameButton>(19);
            this.OnEvent<uFrame.ECS.MouseDownDispatcher>().Subscribe(_=>{ DemoPlayerSystemPointerClickFilter(_); }).DisposeWith(this);
            this.OnEvent<uFrame.Kernel.GameReadyEvent>().Subscribe(_=>{ DemoPlayerSystemGameReadyFilter(_); }).DisposeWith(this);
            this.OnEvent<FlipCube.UserLoggedIn>().Subscribe(_=>{ NotifyLoginFilter(_); }).DisposeWith(this);
            this.PropertyChangedEvent<ClickCount,System.Int32>(Group=>Group.CountObservable, UpdateClickCountFilter, Group=>Group.Count, false);
            this.OnEvent<uFrame.ECS.PointerClickDispatcher>().Subscribe(_=>{ SaveGameButtonClickedFilter(_); }).DisposeWith(this);
        }
        
        protected virtual void DemoPlayerSystemPointerClickHandler(uFrame.ECS.MouseDownDispatcher data, ClickCount source) {
            var handler = new DemoPlayerSystemPointerClickHandler();
            handler.System = this;
            handler.Event = data;
            handler.Source = source;
            StartCoroutine(handler.Execute());
        }
        
        protected void DemoPlayerSystemPointerClickFilter(uFrame.ECS.MouseDownDispatcher data) {
            var SourceClickCount = ClickCountManager[data.EntityId];
            if (SourceClickCount == null) {
                return;
            }
            if (!SourceClickCount.Enabled) {
                return;
            }
            this.DemoPlayerSystemPointerClickHandler(data, SourceClickCount);
        }
        
        protected virtual void DemoPlayerSystemGameReadyHandler(uFrame.Kernel.GameReadyEvent data) {
        }
        
        protected void DemoPlayerSystemGameReadyFilter(uFrame.Kernel.GameReadyEvent data) {
            this.DemoPlayerSystemGameReadyHandler(data);
        }
        
        protected virtual void NotifyLoginHandler(FlipCube.UserLoggedIn data) {
        }
        
        protected void NotifyLoginFilter(FlipCube.UserLoggedIn data) {
            this.NotifyLoginHandler(data);
        }
        
        protected virtual void UpdateClickCount(ClickCount data, ClickCount group, PropertyChangedEvent<System.Int32> value) {
            var handler = new UpdateClickCount();
            handler.System = this;
            handler.Event = data;
            handler.Group = group;
            handler.OldValue = value.PreviousValue;
            handler.NewValue = value.CurrentValue;
            StartCoroutine(handler.Execute());
        }
        
        protected void UpdateClickCountFilter(ClickCount data, PropertyChangedEvent<System.Int32> value) {
            var GroupClickCount = ClickCountManager[data.EntityId];
            if (GroupClickCount == null) {
                return;
            }
            if (!GroupClickCount.Enabled) {
                return;
            }
            this.UpdateClickCount(data, GroupClickCount, value);
        }
        
        protected virtual void SaveGameButtonClickedHandler(uFrame.ECS.PointerClickDispatcher data, SaveGameButton source) {
            var handler = new SaveGameButtonClickedHandler();
            handler.System = this;
            handler.Event = data;
            handler.Source = source;
            StartCoroutine(handler.Execute());
        }
        
        protected void SaveGameButtonClickedFilter(uFrame.ECS.PointerClickDispatcher data) {
            var SourceSaveGameButton = SaveGameButtonManager[data.EntityId];
            if (SourceSaveGameButton == null) {
                return;
            }
            if (!SourceSaveGameButton.Enabled) {
                return;
            }
            this.SaveGameButtonClickedHandler(data, SourceSaveGameButton);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("605cea0c-3d21-4aad-a96a-ab0d826ce3f0")]
    public partial class DemoPlayerSystem : DemoPlayerSystemBase {
        
        private static DemoPlayerSystem _Instance;
        
        [UnityEngine.SerializeField()]
        private String _WelcomeMessage;
        
        [UnityEngine.SerializeField()]
        private Text _ClickCountLabel;
        
        public DemoPlayerSystem() {
            Instance = this;
        }
        
        public static DemoPlayerSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
        
        public String WelcomeMessage {
            get {
                return _WelcomeMessage;
            }
            set {
                _WelcomeMessage = value;
            }
        }
        
        public Text ClickCountLabel {
            get {
                return _ClickCountLabel;
            }
            set {
                _ClickCountLabel = value;
            }
        }
    }
}
