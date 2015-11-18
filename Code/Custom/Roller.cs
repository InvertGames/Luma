namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using uFrame.ECS;
    
    
    public partial class Roller {
     
        public GameObject _BottomCube;
        public GameObject _TopCube;

        public bool IsSingleCube
        {
            get { return _BottomCube == null && _TopCube == null; }
        }
        public virtual void UseGravity( bool use, bool onlyVertical = false)
        {
            GetComponent<Rigidbody>().constraints = use ? RigidbodyConstraints.None :
                onlyVertical ? (RigidbodyConstraints)122 : RigidbodyConstraints.FreezeAll;
            GetComponent<Rigidbody>().useGravity = use;
        }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(BottomBackPosition, 0.1f);
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(BottomLeftPosition, 0.1f);
            Gizmos.color = Color.white;
            Gizmos.DrawSphere(BottomRightPosition, 0.1f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(BottomForwardPosition, 0.1f);
        }
    }
}
