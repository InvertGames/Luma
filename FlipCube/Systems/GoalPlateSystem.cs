using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public class GoalPlateSystem : GoalPlateSystemBase {
    protected override void Reset(IEvent e)
    {
        base.Reset(e);
        foreach (var plate in GoalPlateManager.Components)
        {
            plate.GetComponent<BoxCollider>().enabled = true;
        }
    }

    protected override void GravityOnEnter(PlateCubeCollsion data, TurnGravityOnEnter plateid, Cube cubeid)
    {
        base.GravityOnEnter(data, plateid, cubeid);
        cubeid.rigidbody.useGravity = true;
        cubeid.rigidbody.constraints = RigidbodyConstraints.None;
    }
}
