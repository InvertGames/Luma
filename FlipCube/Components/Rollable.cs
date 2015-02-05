using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public partial class Rollable : RollableBase {
    public RollEventData LastRoll { get; set; }

    public virtual Vector3 BottomBackPosition { get; set; }
    public virtual Vector3 BottomForwardPosition { get; set; }
    public virtual Vector3 BottomLeftPosition { get; set; }
    public virtual Vector3 BottomRightPosition { get; set; }

}
