namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using uFrame.ECS;


    public partial class SwitchPlate
    {
        public Vector3 PivotLocalPosition
        {
            get
            {
                switch (Pivot)
                {
                    case SwitchPlatePivot.Back:
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
                switch (Pivot)
                {
                    case SwitchPlatePivot.Back:
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
            get { return transform.TransformPoint(PivotLocalPosition); }
        }
    }
}
