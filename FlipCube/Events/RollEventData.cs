using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public class RollEventData : RollEventDataBase {
        public Vector3 PositionDelta
    {
        get
        {
            return FuturePosition - CurrentPosition;
        }
    }

    public RollEventData(Vector3 center, Vector3 axis, Vector3 direction, float angle, Vector3 currentPosition, Quaternion currentAngles)
    {
        Center = center;
        Axis = axis;
        Direction = direction;
        Angle = angle;
        CurrentPosition = currentPosition;
        CurrentAngles = currentAngles;
        RotateAround(center, axis, angle);
    }

    public void RotateAround(Vector3 center, Vector3 axis, float angle)
    {
        var pos = CurrentPosition;
        var rot = Quaternion.AngleAxis(angle, axis); // get the desired rotation
        var dir = pos - center; // find current direction relative to center
        dir = rot * dir; // rotate the direction
        FuturePosition = center + dir; // define new position
        // rotate object to keep looking at the center:
        var myRot = CurrentAngles;
        FutureAngles = CurrentAngles * (Quaternion.Inverse(myRot) * rot * myRot);
    }
}
