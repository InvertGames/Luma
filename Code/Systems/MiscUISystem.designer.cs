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
    using FlipCube;
    using UnityEngine.UI;
    using UnityEngine;
    using uFrame.Kernel;
    using uFrame.ECS;
    using UniRx;
    
    
    public partial class MiscUISystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<LoadingScreen> _LoadingScreenManager;
        
        private IEcsComponentManagerOf<BackgroundTaskIndicator> _BackgroundTaskIndicatorManager;
        
        public IEcsComponentManagerOf<LoadingScreen> LoadingScreenManager {
            get {
                return _LoadingScreenManager;
            }
            set {
                _LoadingScreenManager = value;
            }
        }
        
        public IEcsComponentManagerOf<BackgroundTaskIndicator> BackgroundTaskIndicatorManager {
            get {
                return _BackgroundTaskIndicatorManager;
            }
            set {
                _BackgroundTaskIndicatorManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            LoadingScreenManager = ComponentSystem.RegisterComponent<LoadingScreen>(29);
            BlackBoardSystem.EnsureBlackBoard<LoadingScreen>();
            BackgroundTaskIndicatorManager = ComponentSystem.RegisterComponent<BackgroundTaskIndicator>(30);
            BlackBoardSystem.EnsureBlackBoard<BackgroundTaskIndicator>();
            this.PropertyChangedEvent<BackgroundTaskIndicator,System.String>(Group=>Group.MessageObservable, TaskIndicatorMessageChangedFilter, Group=>Group.Message, false);
            this.PropertyChangedEvent<BackgroundTaskIndicator,System.Boolean>(Group=>Group.IsRunningObservable, TaskIndicatorIsRunningChangedFilter, Group=>Group.IsRunning, false);
            this.PropertyChangedEvent<LoadingScreen,System.Boolean>(Group=>Group.IsLoadingObservable, LoadingScreenIsLoadingChangedFilter, Group=>Group.IsLoading, false);
            this.PropertyChangedEvent<LoadingScreen,System.String>(Group=>Group.MessageObservable, LoadingScreenMessageChangedFilter, Group=>Group.Message, false);
        }
        
        protected virtual void TaskIndicatorMessageChanged(BackgroundTaskIndicator data, BackgroundTaskIndicator group, PropertyChangedEvent<System.String> value) {
        }
        
        protected void TaskIndicatorMessageChangedFilter(BackgroundTaskIndicator data, PropertyChangedEvent<System.String> value) {
            var GroupBackgroundTaskIndicator = BackgroundTaskIndicatorManager[data.EntityId];
            if (GroupBackgroundTaskIndicator == null) {
                return;
            }
            if (!GroupBackgroundTaskIndicator.Enabled) {
                return;
            }
            this.TaskIndicatorMessageChanged(data, GroupBackgroundTaskIndicator, value);
        }
        
        protected virtual void TaskIndicatorIsRunningChanged(BackgroundTaskIndicator data, BackgroundTaskIndicator group, PropertyChangedEvent<System.Boolean> value) {
        }
        
        protected void TaskIndicatorIsRunningChangedFilter(BackgroundTaskIndicator data, PropertyChangedEvent<System.Boolean> value) {
            var GroupBackgroundTaskIndicator = BackgroundTaskIndicatorManager[data.EntityId];
            if (GroupBackgroundTaskIndicator == null) {
                return;
            }
            if (!GroupBackgroundTaskIndicator.Enabled) {
                return;
            }
            this.TaskIndicatorIsRunningChanged(data, GroupBackgroundTaskIndicator, value);
        }
        
        protected virtual void LoadingScreenIsLoadingChanged(LoadingScreen data, LoadingScreen group, PropertyChangedEvent<System.Boolean> value) {
        }
        
        protected void LoadingScreenIsLoadingChangedFilter(LoadingScreen data, PropertyChangedEvent<System.Boolean> value) {
            var GroupLoadingScreen = LoadingScreenManager[data.EntityId];
            if (GroupLoadingScreen == null) {
                return;
            }
            if (!GroupLoadingScreen.Enabled) {
                return;
            }
            this.LoadingScreenIsLoadingChanged(data, GroupLoadingScreen, value);
        }
        
        protected virtual void LoadingScreenMessageChanged(LoadingScreen data, LoadingScreen group, PropertyChangedEvent<System.String> value) {
        }
        
        protected void LoadingScreenMessageChangedFilter(LoadingScreen data, PropertyChangedEvent<System.String> value) {
            var GroupLoadingScreen = LoadingScreenManager[data.EntityId];
            if (GroupLoadingScreen == null) {
                return;
            }
            if (!GroupLoadingScreen.Enabled) {
                return;
            }
            this.LoadingScreenMessageChanged(data, GroupLoadingScreen, value);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("a99a8a88-981c-4efe-b82c-87092772b650")]
    public partial class MiscUISystem : MiscUISystemBase {
        
        private static MiscUISystem _Instance;
        
        public MiscUISystem() {
            Instance = this;
        }
        
        public static MiscUISystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
