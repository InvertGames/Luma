using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;


// Base class initializes the event listeners.
public class ShiftingPlate : ShiftingPlateBase {
    
    public override void Initialize(IGame game) {
        base.Initialize(game);
    }

    protected override void OnReset(EntityEventData data)
    {
        base.OnReset(data);
        foreach (var item in TransporterPlateManager.Components)
        {
            if (item.IsOn)
            {
                item.transform.position -= item.MoveOffset;
                item.IsOn = false;
            }
        }
    }

    protected override void OnCubeLeave(PlateCubeCollsion data, MoveLeftOnLeave plateid) {
        base.OnCubeLeave(data, plateid);
        plateid.transform.positionTo(1f, plateid.Offset, true);
        plateid.enabled = false;
    }

    protected override void OnRollCompleted(PlateCubeCollsion data, Cube cube, TransporterPlate transporterplate)
    {
        base.OnRollCompleted(data, cube, transporterplate);
        if (transporterplate.IsOn)
        {
            transporterplate.transform.positionTo(2f, -transporterplate.MoveOffset, true);
            cube.transform.positionTo(2f, -transporterplate.MoveOffset, true);
            transporterplate.IsOn = false;
        }
        else
        {
            transporterplate.transform.positionTo(2f, transporterplate.MoveOffset, true);
            cube.transform.positionTo(2f, transporterplate.MoveOffset, true);
            transporterplate.IsOn = true;
        }
        
    }
}
