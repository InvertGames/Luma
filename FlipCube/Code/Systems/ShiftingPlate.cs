using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;


// Base class initializes the event listeners.
public class ShiftingPlate : ShiftingPlateBase {
    
    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
    }
    
    protected override void OnCubeLeave(PlateCubeCollsion data, MoveLeftOnLeave plateid) {
        base.OnCubeLeave(data, plateid);
        plateid.transform.positionTo(1f, plateid.Offset, true);
        plateid.enabled = false;
    }
}
