using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public class SwitchPlateTarget : SwitchPlateTargetBase {
    public Vector3 PivotLocalPosition
    {
        get
        {
            switch (PivotPoint)
            {
                case SwitchPlatePivot.Bottom:
                    return new Vector3(0f, 0f, -0.5f);
                case SwitchPlatePivot.Top:
                    return new Vector3(0f, 0f, 0.5f);
                case SwitchPlatePivot.Left:
                    return new Vector3(-0.5f, 0f, 0f);
                default: // Right
                    return new Vector3(0.5f, 0f, 0f);
            }
        }
    }
    public Vector3 Axis
    {
        get
        {
            switch (PivotPoint)
            {
                case SwitchPlatePivot.Bottom:
                    return Vector3.left;
                case SwitchPlatePivot.Top:
                    return Vector3.right;
                case SwitchPlatePivot.Left:
                    return Vector3.forward;
                default: // Right
                    return Vector3.back;
            }
        }
    }
    public Vector3 PivotPosition
    {
        get
        {
            return transform.TransformPoint(PivotLocalPosition);
        }
    }
}
