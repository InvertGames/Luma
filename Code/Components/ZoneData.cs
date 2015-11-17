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
    using Invert.Json;
    using UniRx;
    using UnityEngine;
    using uFrame.ECS;
    
    
    [uFrame.Attributes.ComponentId(1)]
    [uFrame.Attributes.uFrameIdentifier("a793536c-e4ab-4d73-b925-7d5ae8cb3c34")]
    public partial class ZoneData : uFrame.ECS.EcsComponent {
        
        [UnityEngine.SerializeField()]
        private String _SceneName;
        
        private Subject<PropertyChangedEvent<String>> _SceneNameObservable;
        
        private PropertyChangedEvent<String> _SceneNameEvent;
        
        public override int ComponentId {
            get {
                return 1;
            }
        }
        
        public IObservable<PropertyChangedEvent<String>> SceneNameObservable {
            get {
                return _SceneNameObservable ?? (_SceneNameObservable = new Subject<PropertyChangedEvent<String>>());
            }
        }
        
        public String SceneName {
            get {
                return _SceneName;
            }
            set {
                SetSceneName(value);
            }
        }
        
        public virtual void SetSceneName(String value) {
            SetProperty(ref _SceneName, value, ref _SceneNameEvent, _SceneNameObservable);
        }
    }
}
