using UnityEngine;

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FlipCube;
    using uFrame.Kernel;
    using uFrame.ECS;
    using UniRx;
    
    
    public partial class RollerSystem : RollerSystemBase, uFrame.ECS.ISystemUpdate {
        public void Roll(Roller roller, Vector3 rotationPoint, Vector3 axis, float angle, Vector3 direction)
        {
            roller.StartCoroutine(Roll(roller, new RollStart()
            {
                Axis = axis,
                Center = rotationPoint,
                Angle = angle,
                Direction = direction,
                Player = roller.EntityId,
                CurrentPosition = roller.transform.position,
                CurrentAngles = roller.transform.rotation
            }));
        }
        public virtual IEnumerator Roll(Roller roller, RollStart rollArgs)
        {

            CalculatePositionsHandler(roller);
            this.Publish(new RollStart());
            if (rollArgs == null) yield break;
            roller.IsRolling = true;
            roller.LastRoll = rollArgs;
            roller.UseGravity(false);
            var steps = roller.RollSpeed * 60f;
            var subAngle = rollArgs.Angle / steps;
            var waitFor = roller.RollSpeed / steps;
            // Rotate the cube by the point, axis and angle
            Debug.Log(string.Format("{0} - {1} - {2}", steps, subAngle, waitFor));
            for (var i = 1; i < steps; i++)
            {
                yield return new WaitForSeconds(waitFor);
                roller.transform.RotateAround(rollArgs.Center, rollArgs.Axis, subAngle);
                //if (Math.Abs(i - steps) > 0.01f)

                //waitFor -= (0.003f * steps);
            }
            roller.transform.RotateAround(rollArgs.Center, rollArgs.Axis, subAngle);

            // Make sure the angles are snaping to 90 degrees.
            var vector = roller.gameObject.transform.eulerAngles;
            vector.x = Mathf.Round(vector.x / 90) * 90;
            vector.y = Mathf.Round(vector.y / 90) * 90;
            vector.z = Mathf.Round(vector.z / 90) * 90;
            roller.transform.eulerAngles = vector;

            roller.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            roller.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);

            yield return new WaitForSeconds(0.01f);
            roller.IsRolling = false;
            CalculatePositionsHandler(roller);
            this.Publish(new RollComplete()
            {
                Player = roller.EntityId,
                RollArgs = rollArgs
            });
        
        }

        protected override void OnMoveRollerHandler(MoveRoller data, Roller roller)
        {
            base.OnMoveRollerHandler(data, roller);
            var targetPosition = new Vector3(data.X,data.Y,data.Z);
            roller.StopAllCoroutines();
            var startingOffset = roller.IsSingleCube ? 0.5f : 1f;
            roller.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            roller.gameObject.SetActive(false);
            roller.transform.position = new Vector3(targetPosition.x, targetPosition.y + 15f, targetPosition.z);
            roller.IsRolling = true;
            roller.transform.positionTo(1f, new Vector3(targetPosition.x, targetPosition.y + startingOffset, targetPosition.z)).setOnCompleteHandler((s) =>
            {
                roller.IsRolling = false;
                //            SignalCubeMoved(data);
                roller.gameObject.SetActive(true);
            });

            roller.RestState = RollerState.StandingUp;
            roller.GetComponent<Rigidbody>().useGravity = false;
            roller.UseGravity( false, false);
        }

        protected override void RollBackHandler(MoveBackward data, Roller player)
        {
            base.RollBackHandler(data, player);
            if (player.IsRolling) return;
            if (player.RestState == RollerState.StandingUp)
                player.RestState = RollerState.LayingForward;

            else if (player.RestState == RollerState.LayingAcross)
                player.RestState = RollerState.LayingAcross;

            else if (player.RestState == RollerState.LayingForward)
                player.RestState = RollerState.StandingUp;

            Roll(player, player.BottomBackPosition, Vector3.left, 90.0f, Vector3.back);
        }

        protected override void RollForwardHandler(MoveForward data, Roller player)
        {
            base.RollForwardHandler(data, player);
            if (player.IsRolling) return;

            if (player.RestState == RollerState.StandingUp)
                player.RestState = RollerState.LayingForward;
            else if (player.RestState == RollerState.LayingAcross)
                player.RestState = RollerState.LayingAcross;
            else if (player.RestState == RollerState.LayingForward)
                player.RestState = RollerState.StandingUp;

            Roll(player, player.BottomForwardPosition, Vector3.right, 90.0f, Vector3.forward);
        }

        protected override void RollLeftHandler(MoveLeft data, Roller player)
        {
            base.RollLeftHandler(data, player);
            if (player.IsRolling) return;
            if (player.RestState == RollerState.StandingUp)
                player.RestState = RollerState.LayingAcross;

            else if (player.RestState == RollerState.LayingAcross)
                player.RestState = RollerState.StandingUp;

            Roll(player, player.BottomLeftPosition, Vector3.forward, 90.0f, Vector3.left);
        }

        protected override void RollRightHandler(MoveRight data, Roller player)
        {
            base.RollRightHandler(data, player);
            if (player.IsRolling) return;


            if (player.RestState == RollerState.StandingUp)
                player.RestState = RollerState.LayingAcross;

            else if (player.RestState == RollerState.LayingAcross)
                player.RestState = RollerState.StandingUp;

            Roll(player, player.BottomRightPosition, Vector3.back, 90.0f, Vector3.right);
        }

        /// <summary>
        /// This method is invoked every frame, and upon initialization.  It is purely for reference when moving the cube around.
        /// </summary>
        /// <param name="roller"></param>
        protected override void CalculatePositionsHandler(Roller roller)
        {
            base.CalculatePositionsHandler(roller);
            var transform = roller.transform;


            if (!roller.IsSingleCube)
            {
                if (roller.RestState == RollerState.StandingUp)
                    roller.BottomBackPosition = transform.localPosition + Vector3.down + (Vector3.back * 0.5f);
                else if (roller.RestState == RollerState.LayingAcross)
                    roller.BottomBackPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.back * 0.5f);
                else
                    roller.BottomBackPosition = transform.localPosition + (Vector3.down * 0.5f) + Vector3.back;


                if (roller.RestState == RollerState.StandingUp)
                    roller.BottomForwardPosition = transform.localPosition + Vector3.down + (Vector3.forward * 0.5f);
                else if (roller.RestState == RollerState.LayingAcross)
                    roller.BottomForwardPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.forward * 0.5f);
                else
                    roller.BottomForwardPosition = transform.localPosition + (Vector3.down * 0.5f) + Vector3.forward;


                if (roller.RestState == RollerState.StandingUp)
                    roller.BottomLeftPosition = transform.localPosition + Vector3.down + (Vector3.left * 0.5f);
                else if (roller.RestState == RollerState.LayingAcross)
                    roller.BottomLeftPosition = transform.localPosition + (Vector3.down * 0.5f) + Vector3.left;
                else
                    roller.BottomLeftPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.left * 0.5f);

                if (roller.RestState == RollerState.StandingUp)
                    roller.BottomRightPosition = transform.localPosition + Vector3.down + (Vector3.right * 0.5f);
                else if (roller.RestState == RollerState.LayingAcross)
                    roller.BottomRightPosition = transform.localPosition + (Vector3.down * 0.5f) + Vector3.right;
                else
                    roller.BottomRightPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.right * 0.5f);
            }
            else
            {
                roller.BottomBackPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.back * 0.5f);
                roller.BottomForwardPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.forward * 0.5f);
                roller.BottomLeftPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.left * 0.5f);
                roller.BottomRightPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.right * 0.5f);

                //roller.BottomBackPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.back * 0.5f);
                //roller.BottomForwardPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.forward * 0.5f);
                //roller.BottomLeftPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.left * 0.5f);
                //roller.BottomRightPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.right * 0.5f);

                //if (roller.RestState == RollerState.StandingUp)
                //    roller.BottomBackPosition = transform.localPosition + Vector3.down + (Vector3.back * 0.5f);
                //else if (roller.RestState == RollerState.LayingAcross)
                //    roller.BottomBackPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.back * 0.5f);
                //else
                //    roller.BottomBackPosition = transform.localPosition + (Vector3.down * 0.5f) + Vector3.back;


                //if (roller.RestState == RollerState.StandingUp)
                //    roller.BottomForwardPosition = transform.localPosition + Vector3.down + (Vector3.forward * 0.5f);
                //else if (roller.RestState == RollerState.LayingAcross)
                //    roller.BottomForwardPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.forward * 0.5f);
                //else
                //    roller.BottomForwardPosition = transform.localPosition + (Vector3.down * 0.5f) + Vector3.forward;


                //if (roller.RestState == RollerState.StandingUp)
                //    roller.BottomLeftPosition = transform.localPosition + Vector3.down + (Vector3.left * 0.5f);
                //else if (roller.RestState == RollerState.LayingAcross)
                //    roller.BottomLeftPosition = transform.localPosition + (Vector3.down * 0.5f) + Vector3.left;
                //else
                //    roller.BottomLeftPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.left * 0.5f);

                //if (roller.RestState == RollerState.StandingUp)
                //    roller.BottomRightPosition = transform.localPosition + Vector3.down + (Vector3.right * 0.5f);
                //else if (roller.RestState == RollerState.LayingAcross)
                //    roller.BottomRightPosition = transform.localPosition + (Vector3.down * 0.5f) + Vector3.right;
                //else
                //    roller.BottomRightPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.right * 0.5f);
            }
        }

        protected override void RollerCreated(Roller data, Roller @group)
        {
            base.RollerCreated(data, @group);
            CalculatePositionsHandler(group);
        }
    }
}
