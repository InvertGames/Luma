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
    using Invert.Json;
    using UniRx;
    using UnityEngine;
    using uFrame.ECS;
    
    
    [uFrame.Attributes.ComponentId(44)]
    [uFrame.Attributes.uFrameIdentifier("1760fff0-5bd2-4db6-84de-eb5e035f7fe2")]
    public partial class TeliporterPlate : uFrame.ECS.EcsComponent {
        
        [UnityEngine.SerializeField()]
        private Plate _Target;
        
        private Subject<PropertyChangedEvent<Plate>> _TargetObservable;
        
        private PropertyChangedEvent<Plate> _TargetEvent;
        
        public override int ComponentId {
            get {
                return 44;
            }
        }
        
        public IObservable<PropertyChangedEvent<Plate>> TargetObservable {
            get {
                return _TargetObservable ?? (_TargetObservable = new Subject<PropertyChangedEvent<Plate>>());
            }
        }
        
        public Plate Target {
            get {
                return _Target;
            }
            set {
                SetTarget(value);
            }
        }
        
        public virtual void SetTarget(Plate value) {
            SetProperty(ref _Target, value, ref _TargetEvent, _TargetObservable);
        }
    }
}
