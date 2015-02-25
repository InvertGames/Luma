using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public partial class Rollable : RollableBase {
    public RollEventData LastRoll { get; set; }
    public GameObject _BottomCube;
    public GameObject _TopCube;

    public bool IsSingleCube
    {
        get { return _BottomCube == null && _TopCube == null; }
    }
    public virtual Vector3 BottomBackPosition { get; set; }
    public virtual Vector3 BottomForwardPosition { get; set; }
    public virtual Vector3 BottomLeftPosition { get; set; }
    public virtual Vector3 BottomRightPosition { get; set; }
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
