using UnityEngine;

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.ECS;
    using UniRx;


    public partial class PlayerGravitySystem : PlayerGravitySystemBase
    {
        protected override void HandleGravityHandler(RollComplete data, Roller player)
        {
            //base.HandleGravityHandler(data, player);
            if (player.IsSingleCube)
            {
                var overLeft = Physics.RaycastAll(new Ray(player.transform.position, Vector3.left), 1f);
                var overRight = Physics.RaycastAll(new Ray(player.transform.position, Vector3.right), 1f);
                var overForward = Physics.RaycastAll(new Ray(player.transform.position, Vector3.forward), 1f);
                var overBack = Physics.RaycastAll(new Ray(player.transform.position, Vector3.back), 1f);

                //if (overLeft.Length > 0)
                //{
                //    SignalRolledNextToCube(new CubeInteractionData()
                //    {
                //        CubeA = cube.EntityId,
                //        CubeB = overLeft[0].collider.GetComponent<EntityComponent>().EntityId,
                //        ToThe = CubeMoveDirection.Left
                //    });
                //}
                //if (overRight.Length > 0)
                //{
                //    SignalRolledNextToCube(new CubeInteractionData()
                //    {
                //        CubeA = cube.EntityId,
                //        CubeB = overRight[0].collider.GetComponent<EntityComponent>().EntityId,
                //        ToThe = CubeMoveDirection.Right
                //    });
                //}
                //if (overForward.Length > 0)
                //{
                //    SignalRolledNextToCube(new CubeInteractionData()
                //    {
                //        CubeA = cube.EntityId,
                //        CubeB = overForward[0].collider.GetComponent<EntityComponent>().EntityId,
                //        ToThe = CubeMoveDirection.Forward
                //    });
                //}
                //if (overBack.Length > 0)
                //{
                //    SignalRolledNextToCube(new CubeInteractionData()
                //    {
                //        CubeA = cube.EntityId,
                //        ToThe = CubeMoveDirection.Backwards,
                //        CubeB = overBack[0].collider.GetComponent<EntityComponent>().EntityId
                //    });
                //}
            }
            if (player.RestState == RollerState.StandingUp)
            {
                // Do single raycast
                var over = Physics.RaycastAll(new Ray(player.transform.position, Vector3.down), 2f);
                if (!over.Any(p => p.collider.GetComponent<Plate>() != null))
                {
                    player.GetComponent<Rigidbody>().useGravity = true;
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    //SignalOnFall(new EntityEventData() { EntityId = cube.EntityId });
                    Publish(new PlayerFall() {Player = player.EntityId});
                }
                else
                {
                    this.Publish(new RollCompleteStandingUp()
                    {
                        Player = player.EntityId,
                        Plate = over[0].collider.GetComponent<Entity>().EntityId,
                        RollArgs = data.RollArgs
                    });
                    //SignalRollCompletedStandingUp(new PlateCubeCollsion()
                    //{
                    //    CubeId = cube.EntityId,
                    //    PlateId = over[0].collider.GetComponent<EntityComponent>().EntityId
                    //});
                }
            }
            else
            {
                for (var i = 0; i < player.transform.childCount; i++)
                {
                    var child = player.transform.GetChild(i);
                    var over = Physics.RaycastAll(new Ray(child.transform.position, Vector3.down), 1f);


                    if (!over.Any(p => p.collider.GetComponent<Plate>() != null))
                    {

                        player.GetComponent<Rigidbody>().useGravity = true;
                        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                        Publish(new PlayerFall() { Player = player.EntityId });
                        return;
                    }
                }
            }
        }
    }
}
