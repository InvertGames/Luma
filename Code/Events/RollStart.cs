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
    using UniRx;
    using UnityEngine;
    
    
    [uFrame.Attributes.EventId(15)]
    public partial class RollStart : object {
        
        [UnityEngine.SerializeField()]
        private Int32 _Player;
        
        [UnityEngine.SerializeField()]
        private Vector3 _Center;
        
        [UnityEngine.SerializeField()]
        private Single _Angle;
        
        [UnityEngine.SerializeField()]
        private Vector3 _Direction;
        
        [UnityEngine.SerializeField()]
        private Quaternion _CurrentAngles;
        
        [UnityEngine.SerializeField()]
        private Vector3 _Axis;
        
        [UnityEngine.SerializeField()]
        private Vector3 _CurrentPosition;
        
        public Int32 Player {
            get {
                return _Player;
            }
            set {
                _Player = value;
            }
        }
        
        public Vector3 Center {
            get {
                return _Center;
            }
            set {
                _Center = value;
            }
        }
        
        public Single Angle {
            get {
                return _Angle;
            }
            set {
                _Angle = value;
            }
        }
        
        public Vector3 Direction {
            get {
                return _Direction;
            }
            set {
                _Direction = value;
            }
        }
        
        public Quaternion CurrentAngles {
            get {
                return _CurrentAngles;
            }
            set {
                _CurrentAngles = value;
            }
        }
        
        public Vector3 Axis {
            get {
                return _Axis;
            }
            set {
                _Axis = value;
            }
        }
        
        public Vector3 CurrentPosition {
            get {
                return _CurrentPosition;
            }
            set {
                _CurrentPosition = value;
            }
        }
    }
}
