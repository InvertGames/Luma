using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using Invert.ECS.Unity;
using UnityEngine;


// Base class initializes the event listeners.
public class CubeSystem : CubeSystemBase
{

    public override void Initialize(Invert.ECS.IGame game)
    {
        base.Initialize(game);
        foreach (var item in game.ComponentSystem.GetAllComponents<Rollable>())
        {
            CalculatePositions(item);
        }
    }

    protected override void OnNextToCube(CubeInteractionData data, Rollable rollable)
    {
        base.OnNextToCube(data, rollable);
        var cube = RollableManager.Components.FirstOrDefault(p => p.EntityId == 1);

        var a = rollable;
        Rollable b;
        if (Game.ComponentSystem.TryGetComponent(data.CubeB, out b))
        {
            
            Vector3 midPoint = (a.transform.position + b.transform.position) * 0.5f;
            cube.transform.position = midPoint;

            if (data.ToThe == CubeMoveDirection.Left || data.ToThe == CubeMoveDirection.Right)
            {
                cube.transform.rotation = Quaternion.Euler(0, 180f, 90f);
                cube.RestState = RollerState.LayingAcross;
            }
            else
            {
                cube.RestState = RollerState.LayingForward;
                cube.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
            AttachCube(cube, a, b);
            CubeInputSystem.SignalSelected(Game, new EntityEventData()
            {
                EntityId = 1,
                // Position = data.TargetPositionB,
            });
            
        }
        
        
    }

    private void AttachCube(Rollable mainCube, Rollable a, Rollable b)
    {
        mainCube.IsSplit = false;
        a.transform.parent = mainCube.transform;
        b.transform.parent = mainCube.transform;
        a.transform.localRotation = Quaternion.identity;
        b.transform.localRotation = Quaternion.identity;

        TurnCubeOn(a.transform, false);
        TurnCubeOn(b.transform, false);
        TurnCubeOn(mainCube.transform, true);
        a.transform.localPosition = new Vector3(0f, -0.5f, 0f);
        b.transform.localPosition = new Vector3(0f, 0.5f, 0f);
    }

    protected override void OnSplit(SplitCubeData data, Rollable rollable)
    {
        base.OnSplit(data, rollable);
        if (rollable.IsSingleCube) return;

        TurnCubeOn(rollable.transform, false);
        rollable.IsSplit = true;
        for (var i = 0; i < rollable.transform.childCount; i++)
        {
            var childCube = rollable.transform.GetChild(i);
            TurnCubeOn(childCube,true);
        } 
        rollable.transform.DetachChildren();
        SignalMoveTo(new MoveCubeData()
        {
            CubeId = 2,
            Position = data.TargetPositionA,
        });
        SignalMoveTo(new MoveCubeData()
        {
            CubeId = 3,
            Position = data.TargetPositionB,
        });
        CubeInputSystem.SignalSelected(Game,new EntityEventData()
        {
            EntityId = 2,
           // Position = data.TargetPositionB,
        });
    }

    private static void TurnCubeOn(Transform childCube, bool on )
    {
        foreach (var item in childCube.GetComponents<UnityComponent>())
        {
            item.enabled = on;
        }
        childCube.GetComponent<BoxCollider>().enabled = on;
        if (on)
        {
            var rb = childCube.gameObject.GetComponent<Rigidbody>();
            if (rb == null)
                childCube.gameObject.AddComponent<Rigidbody>();
        }
        else
        {
            var rb = childCube.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                DestroyImmediate(rb);
            }
        }
        
    }

    protected override void OnReset(EntityEventData data, Rollable component)
    {
        base.OnReset(data, component);
        
        if (!component.IsSingleCube)
        {
            if (component.IsSplit)
            {
                Rollable a;
                Rollable b;
                if (Game.ComponentSystem.TryGetComponent(2, out a) && Game.ComponentSystem.TryGetComponent(3, out b))
                {
                    AttachCube(component, a, b);
                }
            }

            SignalMoveTo(new MoveCubeData() { CubeId = component.EntityId, Position = component.StartingPosition });
            Debug.Log("Moving To Start Position");
        }
        
        
    }

    protected override void MoveCube(MoveCubeData data, Rollable cube)
    {
        base.MoveCube(data, cube);
        var targetPosition = data.Position;
        cube.StopAllCoroutines();
        var startingOffset = cube.IsSingleCube ? 0.5f : 1f;
        cube.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        cube.transform.position = new Vector3(targetPosition.x, targetPosition.y + 15f, targetPosition.z);
        cube.IsRolling = true;
        cube.transform.positionTo(1f, new Vector3(targetPosition.x, targetPosition.y + startingOffset, targetPosition.z)).setOnCompleteHandler((s) =>
        {
            cube.IsRolling = false;
        });

        cube.RestState = RollerState.StandingUp;
        cube.rigidbody.useGravity = false;
        UseGravity(cube, false, false);
    }

    public override void Update()
    {
        base.Update();
        if (RollableManager == null) return;
        foreach (var component in RollableManager.Components)
        {
            CalculatePositions(component);
        }
    }

    public virtual IEnumerator Roll(Rollable roller, RollEventData rollArgs)
    {

        CalculatePositions(roller);
        SignalRollBegin(rollArgs);
        if (rollArgs == null) yield break;
        roller.IsRolling = true;
        roller.LastRoll = rollArgs;
        UseGravity(roller, false);
        var steps = roller.RollSpeed * 60f;
        var subAngle = rollArgs.Angle / steps;
        var waitFor = roller.RollSpeed/steps;
        // Rotate the cube by the point, axis and angle
        Debug.Log(string.Format("{0} - {1} - {2}", steps,subAngle,waitFor));
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

        roller.gameObject.rigidbody.velocity = new Vector3(0f, 0f, 0f);
        roller.gameObject.rigidbody.angularVelocity = new Vector3(0f, 0f, 0f);

        yield return new WaitForSeconds(0.01f);
        roller.IsRolling = false;
        CalculatePositions(roller);
        SignalRollComplete(rollArgs);
    }

    protected override void ComponentCreated(IEvent e)
    {
        base.ComponentCreated(e);
        var rollable = e.Data as Rollable;
        if (rollable != null)
        {
            CalculatePositions(rollable);

        }
    }
    protected override void OnForward(EntityEventData data, Rollable roller)
    {
        base.OnForward(data, roller);

        if (roller.IsRolling) return;

        if (roller.RestState == RollerState.StandingUp)
            roller.RestState = RollerState.LayingForward;
        else if (roller.RestState == RollerState.LayingAcross)
            roller.RestState = RollerState.LayingAcross;
        else if (roller.RestState == RollerState.LayingForward)
            roller.RestState = RollerState.StandingUp;

        Roll(roller, roller.BottomForwardPosition, Vector3.right, 90.0f, Vector3.forward);

    }
    protected override void OnBackwards(EntityEventData data, Rollable roller)
    {
        base.OnForward(data, roller);
        if (roller.IsRolling) return;
        if (roller.RestState == RollerState.StandingUp)
            roller.RestState = RollerState.LayingForward;

        else if (roller.RestState == RollerState.LayingAcross)
            roller.RestState = RollerState.LayingAcross;

        else if (roller.RestState == RollerState.LayingForward)
            roller.RestState = RollerState.StandingUp;

        Roll(roller, roller.BottomBackPosition, Vector3.left, 90.0f, Vector3.back);
    }
    protected override void OnLeft(EntityEventData data, Rollable roller)
    {
        base.OnForward(data, roller);
        if (roller.IsRolling) return;
        if (roller.RestState == RollerState.StandingUp)
            roller.RestState = RollerState.LayingAcross;

        else if (roller.RestState == RollerState.LayingAcross)
            roller.RestState = RollerState.StandingUp;

        Roll(roller, roller.BottomLeftPosition, Vector3.forward, 90.0f, Vector3.left);
    }
    protected override void OnRight(EntityEventData data, Rollable roller)
    {
        base.OnForward(data, roller);

        if (roller.IsRolling) return;

        
        if (roller.RestState == RollerState.StandingUp)
            roller.RestState = RollerState.LayingAcross;

        else if (roller.RestState == RollerState.LayingAcross)
            roller.RestState = RollerState.StandingUp;

        Roll(roller, roller.BottomRightPosition, Vector3.back, 90.0f, Vector3.right);

    }

    protected void CalculatePositions(Rollable roller)
    {
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
            roller.BottomBackPosition = transform.localPosition + (Vector3.down*0.5f) + (Vector3.back*0.5f);
            roller.BottomForwardPosition = transform.localPosition + (Vector3.down*0.5f) + (Vector3.forward*0.5f);
            roller.BottomLeftPosition = transform.localPosition + (Vector3.down*0.5f) + (Vector3.left*0.5f);
            roller.BottomRightPosition = transform.localPosition + (Vector3.down*0.5f) + (Vector3.right*0.5f);

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

    public virtual void UseGravity(Rollable roller, bool use, bool onlyVertical = false)
    {
        roller.rigidbody.constraints = use ? RigidbodyConstraints.None :
            onlyVertical ? (RigidbodyConstraints)122 : RigidbodyConstraints.FreezeAll;
        roller.rigidbody.useGravity = use;
    }

    public void Roll(Rollable roller, Vector3 rotationPoint, Vector3 axis, float angle, Vector3 direction)
    {
        roller.StartCoroutine(Roll(roller, new RollEventData(rotationPoint, axis, direction, angle, roller.transform.position, roller.transform.rotation)
        {
            Axis = axis,
            Center = rotationPoint,
            Angle = angle,
            Direction = direction,
            EntityId = roller.EntityId
        }));
    }

}
