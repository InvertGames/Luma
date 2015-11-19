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
    using UnityEngine;
    using uFrame.ECS;
    using Invert.Json;
    using UniRx;
    
    
    [uFrame.Attributes.ComponentId(27)]
    [uFrame.Attributes.uFrameIdentifier("b6f032b6-2750-4db5-a1e3-1cec14ff4078")]
    public partial class Plate : uFrame.ECS.EcsComponent {
        
        [UnityEngine.SerializeField()]
        private Vector3 _StartPosition;
        
        private Subject<PropertyChangedEvent<Vector3>> _StartPositionObservable;
        
        private PropertyChangedEvent<Vector3> _StartPositionEvent;
        
        public override int ComponentId {
            get {
                return 27;
            }
        }
        
        public IObservable<PropertyChangedEvent<Vector3>> StartPositionObservable {
            get {
                return _StartPositionObservable ?? (_StartPositionObservable = new Subject<PropertyChangedEvent<Vector3>>());
            }
        }
        
        public Vector3 StartPosition {
            get {
                return _StartPosition;
            }
            set {
                SetStartPosition(value);
            }
        }
        
        public virtual void SetStartPosition(Vector3 value) {
            SetProperty(ref _StartPosition, value, ref _StartPositionEvent, _StartPositionObservable);
        }
    }
}
