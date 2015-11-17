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
    using uFrame.ECS;
    using UniRx;
    using Invert.Json;
    using UnityEngine;
    
    
    [uFrame.Attributes.ComponentId(37)]
    [uFrame.Attributes.uFrameIdentifier("795220dd-9898-4e55-86f8-4c3d631f2207")]
    public partial class Dialog : uFrame.ECS.EcsComponent {
        
        [UnityEngine.SerializeField()]
        private String _Header;
        
        [UnityEngine.SerializeField()]
        private String _IconName;
        
        [UnityEngine.SerializeField()]
        private DialogAction _DefaultAction;
        
        [UnityEngine.SerializeField()]
        private String _Message;
        
        [UnityEngine.SerializeField()]
        private Int32 _Timeout;
        
        [UnityEngine.SerializeField()]
        private DialogAction[] _Actions;
        
        private ReactiveCollection<DialogAction> _ActionsReactive;
        
        private Subject<PropertyChangedEvent<String>> _HeaderObservable;
        
        private PropertyChangedEvent<String> _HeaderEvent;
        
        private Subject<PropertyChangedEvent<String>> _IconNameObservable;
        
        private PropertyChangedEvent<String> _IconNameEvent;
        
        private Subject<PropertyChangedEvent<DialogAction>> _DefaultActionObservable;
        
        private PropertyChangedEvent<DialogAction> _DefaultActionEvent;
        
        private Subject<PropertyChangedEvent<String>> _MessageObservable;
        
        private PropertyChangedEvent<String> _MessageEvent;
        
        private Subject<PropertyChangedEvent<Int32>> _TimeoutObservable;
        
        private PropertyChangedEvent<Int32> _TimeoutEvent;
        
        public override int ComponentId {
            get {
                return 37;
            }
        }
        
        public IObservable<PropertyChangedEvent<String>> HeaderObservable {
            get {
                return _HeaderObservable ?? (_HeaderObservable = new Subject<PropertyChangedEvent<String>>());
            }
        }
        
        public IObservable<PropertyChangedEvent<String>> IconNameObservable {
            get {
                return _IconNameObservable ?? (_IconNameObservable = new Subject<PropertyChangedEvent<String>>());
            }
        }
        
        public IObservable<PropertyChangedEvent<DialogAction>> DefaultActionObservable {
            get {
                return _DefaultActionObservable ?? (_DefaultActionObservable = new Subject<PropertyChangedEvent<DialogAction>>());
            }
        }
        
        public IObservable<PropertyChangedEvent<String>> MessageObservable {
            get {
                return _MessageObservable ?? (_MessageObservable = new Subject<PropertyChangedEvent<String>>());
            }
        }
        
        public IObservable<PropertyChangedEvent<Int32>> TimeoutObservable {
            get {
                return _TimeoutObservable ?? (_TimeoutObservable = new Subject<PropertyChangedEvent<Int32>>());
            }
        }
        
        public String Header {
            get {
                return _Header;
            }
            set {
                SetHeader(value);
            }
        }
        
        public String IconName {
            get {
                return _IconName;
            }
            set {
                SetIconName(value);
            }
        }
        
        public DialogAction DefaultAction {
            get {
                return _DefaultAction;
            }
            set {
                SetDefaultAction(value);
            }
        }
        
        public String Message {
            get {
                return _Message;
            }
            set {
                SetMessage(value);
            }
        }
        
        public Int32 Timeout {
            get {
                return _Timeout;
            }
            set {
                SetTimeout(value);
            }
        }
        
        public ReactiveCollection<DialogAction> Actions {
            get {
                if (_ActionsReactive == null) {
                    _ActionsReactive = new ReactiveCollection<DialogAction>(_Actions ?? new DialogAction[] { });
                }
                return _ActionsReactive;
            }
        }
        
        public virtual void SetHeader(String value) {
            SetProperty(ref _Header, value, ref _HeaderEvent, _HeaderObservable);
        }
        
        public virtual void SetIconName(String value) {
            SetProperty(ref _IconName, value, ref _IconNameEvent, _IconNameObservable);
        }
        
        public virtual void SetDefaultAction(DialogAction value) {
            SetProperty(ref _DefaultAction, value, ref _DefaultActionEvent, _DefaultActionObservable);
        }
        
        public virtual void SetMessage(String value) {
            SetProperty(ref _Message, value, ref _MessageEvent, _MessageObservable);
        }
        
        public virtual void SetTimeout(Int32 value) {
            SetProperty(ref _Timeout, value, ref _TimeoutEvent, _TimeoutObservable);
        }
    }
}
