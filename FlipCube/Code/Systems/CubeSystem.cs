using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class CubeSystem : CubeSystemBase {
    
    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
        foreach (var item in game.ComponentSystem.GetAllComponents<Rollable>())
        {
            CalculatePositions(item);
        }
        
    }

    protected override void OnReset(EntityEventData data, Rollable component)
    {
        base.OnReset(data, component);
        
        //component.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //component.transform.position = new Vector3(0f, 15f, 0f);
        //component.transform.positionTo(1f, new Vector3(0f, 1f, 0f));
        SignalMoveTo(new MoveCubeData() {CubeId = component.EntityId, Position = component.StartingPosition});
        Debug.Log("Moving To Start Position");
    }

    protected override void MoveCube(MoveCubeData data, Rollable cube)
    {
        base.MoveCube(data, cube);
        var targetPosition = data.Position;
        cube.StopAllCoroutines();
        
        cube.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        cube.transform.position = new Vector3(targetPosition.x, 15f, targetPosition.z);
        cube.IsRolling = true;
        cube.transform.positionTo(1f, new Vector3(targetPosition.x, 1f, targetPosition.z)).setOnCompleteHandler((s) =>
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
        foreach (var component in Game.ComponentSystem.GetAllComponents<Rollable>())
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
        var steps = Mathf.Ceil(roller.RollSpeed * 30.0f);
        var subAngle = rollArgs.Angle / steps;
        var waitFor = 0.023333f;
        // Rotate the cube by the point, axis and angle
        for (var i = 1; i <= steps; i++)
        {
            roller.transform.RotateAround(rollArgs.Center, rollArgs.Axis, subAngle);
            if (Math.Abs(i - steps) > 0.01f)
                yield return new WaitForSeconds(waitFor);
            waitFor -= (0.003f * steps);
        }

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
        roller.BottomBackPosition = roller.RestState == RollerState.StandingUp
                ? transform.localPosition + Vector3.down + (Vector3.back * 0.5f)
                : roller.RestState == RollerState.LayingAcross
                    ? transform.localPosition + (Vector3.down * 0.5f) + (Vector3.back * 0.5f)
                    : transform.localPosition + (Vector3.down * 0.5f) + Vector3.back;

        roller.BottomForwardPosition = roller.RestState == RollerState.StandingUp
                ? transform.localPosition + Vector3.down + (Vector3.forward * 0.5f)
                : roller.RestState == RollerState.LayingAcross
                    ? transform.localPosition + (Vector3.down * 0.5f) + (Vector3.forward * 0.5f)
                    : transform.localPosition + (Vector3.down * 0.5f) + Vector3.forward;

        if (roller.RestState == RollerState.StandingUp)
            roller.BottomLeftPosition = transform.localPosition + Vector3.down + (Vector3.left * 0.5f);
        else if (roller.RestState == RollerState.LayingAcross)
            roller.BottomLeftPosition = transform.localPosition + (Vector3.down*0.5f) + Vector3.left;
        else
            roller.BottomLeftPosition = transform.localPosition + (Vector3.down*0.5f) + (Vector3.left*0.5f);

        if (roller.RestState == RollerState.StandingUp) 
            roller.BottomRightPosition = transform.localPosition + Vector3.down + (Vector3.right * 0.5f);
        else if (roller.RestState == RollerState.LayingAcross) 
            roller.BottomRightPosition = transform.localPosition + (Vector3.down * 0.5f) + Vector3.right;
        else roller.BottomRightPosition = transform.localPosition + (Vector3.down * 0.5f) + (Vector3.right * 0.5f);
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
//public class RollArgs
//{
//    public float Angle { get; set; }

//    public Vector3 Axis { get; set; }

//    public Vector3 Center { get; set; }

//    public Quaternion CurrentAngles
//    {
//        get;
//        set;
//    }

//    public Vector3 CurrentPosition
//    {
//        get;
//        set;
//    }

//    public Vector3 Direction { get; set; }

//    public Quaternion FutureAngles
//    {
//        get;
//        set;
//    }

//    public Vector3 FuturePosition
//    {
//        get;
//        set;
//    }

//    public Vector3 PositionDelta
//    {
//        get
//        {
//            return FuturePosition - CurrentPosition;
//        }
//    }

//    public RollArgs(Vector3 center, Vector3 axis, Vector3 direction, float angle, Vector3 currentPosition, Quaternion currentAngles)
//    {
//        Center = center;
//        Axis = axis;
//        Direction = direction;
//        Angle = angle;
//        CurrentPosition = currentPosition;
//        CurrentAngles = currentAngles;
//        RotateAround(center, axis, angle);
//    }

//    public void RotateAround(Vector3 center, Vector3 axis, float angle)
//    {
//        var pos = CurrentPosition;
//        var rot = Quaternion.AngleAxis(angle, axis); // get the desired rotation
//        var dir = pos - center; // find current direction relative to center
//        dir = rot * dir; // rotate the direction
//        FuturePosition = center + dir; // define new position
//        // rotate object to keep looking at the center:
//        var myRot = CurrentAngles;
//        FutureAngles = CurrentAngles * (Quaternion.Inverse(myRot) * rot * myRot);
//    }
//}