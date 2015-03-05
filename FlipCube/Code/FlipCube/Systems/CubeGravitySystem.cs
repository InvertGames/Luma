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
        if (rollable.IsSingleCube)
        {
            var overLeft = Physics.RaycastAll(new Ray(cube.transform.position, Vector3.left), 1f);
            var overRight = Physics.RaycastAll(new Ray(cube.transform.position, Vector3.right), 1f);
            var overForward = Physics.RaycastAll(new Ray(cube.transform.position, Vector3.forward), 1f);
            var overBack = Physics.RaycastAll(new Ray(cube.transform.position, Vector3.back), 1f);

            if (overLeft.Length > 0)
            {
                SignalRolledNextToCube(new CubeInteractionData()
                {
                    CubeA = cube.EntityId,
                    CubeB = overLeft[0].collider.GetComponent<EntityComponent>().EntityId,
                    ToThe = CubeMoveDirection.Left
                });
            }
            if (overRight.Length > 0)
            {
                SignalRolledNextToCube(new CubeInteractionData()
                {
                    CubeA = cube.EntityId,
                    CubeB = overRight[0].collider.GetComponent<EntityComponent>().EntityId,
                    ToThe = CubeMoveDirection.Right
                });
            }
            if (overForward.Length > 0)
            {
                SignalRolledNextToCube(new CubeInteractionData()
                {
                    CubeA = cube.EntityId,
                    CubeB = overForward[0].collider.GetComponent<EntityComponent>().EntityId,
                    ToThe = CubeMoveDirection.Forward
                });
            }
            if (overBack.Length > 0)
            {
                SignalRolledNextToCube(new CubeInteractionData()
                {
                    CubeA = cube.EntityId,
                    ToThe = CubeMoveDirection.Backwards,
                    CubeB = overBack[0].collider.GetComponent<EntityComponent>().EntityId
                });
            }
        }
        if (rollable.RestState == RollerState.StandingUp)
        {
            // Do single raycast
            var over = Physics.RaycastAll(new Ray(cube.transform.position, Vector3.down),2f);
            if (!over.Any(p => p.collider.GetComponent<Plate>() != null))
            {
                cube.GetComponent<Rigidbody>().useGravity = true;
                cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
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
                var over = Physics.RaycastAll(new Ray(child.transform.position, Vector3.down),1f);


                if (!over.Any(p => p.collider.GetComponent<Plate>() != null))
                {

                    cube.GetComponent<Rigidbody>().useGravity = true;
                    cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                    SignalOnFall(new EntityEventData() { EntityId = cube.EntityId });
                    return;
                }


            }
        }
    }
}
