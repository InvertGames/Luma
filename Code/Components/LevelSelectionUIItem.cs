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
    using UnityEngine.UI;
    using uFrame.ECS;
    using Invert.Json;
    using UnityEngine;
    using UniRx;
    
    
    [uFrame.Attributes.ComponentId(45)]
    [uFrame.Attributes.uFrameIdentifier("6b3f8a18-e621-4070-aaa4-a108e2cb6b84")]
    public partial class LevelSelectionUIItem : uFrame.ECS.EcsComponent {
        
        [UnityEngine.SerializeField()]
        private Text _LevelTitleText;
        
        [UnityEngine.SerializeField()]
        private Int32 _LevelIndex;
        
        private Subject<PropertyChangedEvent<Text>> _LevelTitleTextObservable;
        
        private PropertyChangedEvent<Text> _LevelTitleTextEvent;
        
        private Subject<PropertyChangedEvent<Int32>> _LevelIndexObservable;
        
        private PropertyChangedEvent<Int32> _LevelIndexEvent;
        
        public override int ComponentId {
            get {
                return 45;
            }
        }
        
        public IObservable<PropertyChangedEvent<Text>> LevelTitleTextObservable {
            get {
                return _LevelTitleTextObservable ?? (_LevelTitleTextObservable = new Subject<PropertyChangedEvent<Text>>());
            }
        }
        
        public IObservable<PropertyChangedEvent<Int32>> LevelIndexObservable {
            get {
                return _LevelIndexObservable ?? (_LevelIndexObservable = new Subject<PropertyChangedEvent<Int32>>());
            }
        }
        
        public Text LevelTitleText {
            get {
                return _LevelTitleText;
            }
            set {
                SetLevelTitleText(value);
            }
        }
        
        public Int32 LevelIndex {
            get {
                return _LevelIndex;
            }
            set {
                SetLevelIndex(value);
            }
        }
        
        public virtual void SetLevelTitleText(Text value) {
            SetProperty(ref _LevelTitleText, value, ref _LevelTitleTextEvent, _LevelTitleTextObservable);
        }
        
        public virtual void SetLevelIndex(Int32 value) {
            SetProperty(ref _LevelIndex, value, ref _LevelIndexEvent, _LevelIndexObservable);
        }
    }
}
