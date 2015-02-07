using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using Invert.ECS.Unity;
using UnityEngine;


// Base class initializes the event listeners.
public class CubeGravitySystem : CubeGravitySystemBase
{
    protected override void RollCompleted(RollEventData data, Cube cube, Rollable rollable)
    {
        base.RollCompleted(data, cube, rollable);
        if (rollable.RestState == RollerState.StandingUp)
        {
            // Do single raycast
            var over = Physics.RaycastAll(new Ray(cube.transform.position, Vector3.down));
            if (!over.Any(p => p.collider.GetComponent<Plate>() != null))
            {
                cube.rigidbody.useGravity = true;
                cube.rigidbody.constraints = RigidbodyConstraints.None;
                SignalOnFall(new EntityEventData() { EntityId = cube.EntityId });
            }
            else
            {
                SignalRollCompletedStandingUp(new PlateCubeCollsion()
                {
                    CubeId = cube.EntityId,
                    PlateId = over[0].collider.GetComponent<EntityComponent>().EntityId
                });
            }
        }
        else
        {
            for (var i = 0; i < rollable.transform.childCount; i++)
            {
                var child = rollable.transform.GetChild(i);
                var over = Physics.RaycastAll(new Ray(child.transform.position, Vector3.down));


                if (!over.Any(p => p.collider.GetComponent<Plate>() != null))
                {

                    cube.rigidbody.useGravity = true;
                    cube.rigidbody.constraints = RigidbodyConstraints.None;

                    SignalOnFall(new EntityEventData() { EntityId = cube.EntityId });
                    return;
                }


            }
        }
    }
}
