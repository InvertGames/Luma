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
    using uFrame.ECS;
    using UniRx;
    using UnityEngine;
    
    
    [uFrame.Attributes.ComponentId(23)]
    [uFrame.Attributes.uFrameIdentifier("15c43187-0bc7-4e7d-bf44-ff87abb36299")]
    public partial class UserLoginInfo : uFrame.ECS.EcsComponent, uFrame.ECS.IBlackBoardComponent {
        
        [UnityEngine.SerializeField()]
        private Boolean _IsLoggedIn;
        
        private Subject<PropertyChangedEvent<Boolean>> _IsLoggedInObservable;
        
        private PropertyChangedEvent<Boolean> _IsLoggedInEvent;
        
        public override int ComponentId {
            get {
                return 23;
            }
        }
        
        public IObservable<PropertyChangedEvent<Boolean>> IsLoggedInObservable {
            get {
                return _IsLoggedInObservable ?? (_IsLoggedInObservable = new Subject<PropertyChangedEvent<Boolean>>());
            }
        }
        
        public Boolean IsLoggedIn {
            get {
                return _IsLoggedIn;
            }
            set {
                SetIsLoggedIn(value);
            }
        }
        
        public virtual void SetIsLoggedIn(Boolean value) {
            SetProperty(ref _IsLoggedIn, value, ref _IsLoggedInEvent, _IsLoggedInObservable);
        }
    }
}
