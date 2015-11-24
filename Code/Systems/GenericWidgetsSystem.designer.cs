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
    using UnityEngine;
    
    
    public partial class GenericWidgetsSystemBase : uFrame.ECS.EcsSystem {
        
        private IEcsComponentManagerOf<LoadingPanelWidget> _LoadingPanelWidgetManager;
        
        private IEcsComponentManagerOf<LoadingPanel> _LoadingPanelManager;
        
        public IEcsComponentManagerOf<LoadingPanelWidget> LoadingPanelWidgetManager {
            get {
                return _LoadingPanelWidgetManager;
            }
            set {
                _LoadingPanelWidgetManager = value;
            }
        }
        
        public IEcsComponentManagerOf<LoadingPanel> LoadingPanelManager {
            get {
                return _LoadingPanelManager;
            }
            set {
                _LoadingPanelManager = value;
            }
        }
        
        public override void Setup() {
            base.Setup();
            LoadingPanelWidgetManager = ComponentSystem.RegisterGroup<LoadingPanelWidgetGroup,LoadingPanelWidget>();
            LoadingPanelManager = ComponentSystem.RegisterComponent<LoadingPanel>(74);
            this.PropertyChangedEvent<LoadingPanelWidget,System.String>(Group=>Group.LoadingPanel.MessageObservable, OnLoadingPanelMessageChangedFilter, Group=>Group.LoadingPanel.Message, false);
        }
        
        protected virtual void OnLoadingPanelMessageChanged(LoadingPanelWidget data, LoadingPanelWidget group, PropertyChangedEvent<System.String> value) {
        }
        
        protected void OnLoadingPanelMessageChangedFilter(LoadingPanelWidget data, PropertyChangedEvent<System.String> value) {
            var GroupItem = LoadingPanelWidgetManager[data.EntityId];
            if (GroupItem == null) {
                return;
            }
            if (!GroupItem.Enabled) {
                return;
            }
            this.OnLoadingPanelMessageChanged(data, GroupItem, value);
        }
    }
    
    [uFrame.Attributes.uFrameIdentifier("9a8bb979-1a44-488a-acfe-e27a72b2253d")]
    public partial class GenericWidgetsSystem : GenericWidgetsSystemBase {
        
        private static GenericWidgetsSystem _Instance;
        
        public GenericWidgetsSystem() {
            Instance = this;
        }
        
        public static GenericWidgetsSystem Instance {
            get {
                return _Instance;
            }
            set {
                _Instance = value;
            }
        }
    }
}
