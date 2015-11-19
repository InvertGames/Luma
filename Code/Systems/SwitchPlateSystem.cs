using UnityEngine;

namespace FlipCube {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.ECS;
    using UniRx;
    
    
    public partial class SwitchPlateSystem : SwitchPlateSystemBase {
        protected override void ResetSwitchPlateHandler(LevelReset data, SwitchPlate switchPlate)
        {
            if (switchPlate.On && !switchPlate.StartOn)
            {
                switchPlate.On = switchPlate.StartOn;
            }
         
        }

        protected override void ResetSwitchPlateTriggerHandler(LevelReset data, SwitchPlateTrigger @group)
        {
            base.ResetSwitchPlateTriggerHandler(data, @group);
        }

       /* protected override void LandedOnTriggerHandler(RollCompleteStandingUp data, Roller player, SwitchPlateTrigger plate)
        {
            base.LandedOnTriggerHandler(data, player, plate);

            foreach (var target in SwitchPlateManager.Components.Where(p => p.GroupNumber == plate.GroupNumber))
            {
             
                target.On = !target.On;

            }

        }*/

        protected override void OnChanged(SwitchPlate data, SwitchPlate target, PropertyChangedEvent<bool> value)
        {
            target.StartCoroutine(RotateAround(target, 0.2f, !target.On ? -90 : 90));
        }

        public IEnumerator RotateAround(SwitchPlate target, float timeInSeconds, float angle)
        {

            var steps = Mathf.Ceil(timeInSeconds * 30.0f);
            var subAngle = angle / steps;

            // Rotate the cube by the point, axis and angle
            for (var i = 1; i <= steps; i++)
            {

                target.transform.RotateAround(target.PivotPosition, target.Axis, subAngle);
                if (Math.Abs(i - steps) > 0.01f)
                    yield return new WaitForSeconds(0.023333f);
            }
            //Snap
            var vector = target.transform.eulerAngles;
            vector.x = Mathf.Round(vector.x / 90) * 90;
            vector.y = Mathf.Round(vector.y / 90) * 90;
            vector.z = Mathf.Round(vector.z / 90) * 90;
            target.transform.eulerAngles = vector;


        }

    }
}
