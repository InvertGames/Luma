using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class SwitchPlateSystem : SwitchPlateSystemBase {
    
    public override void Initialize(IGame game) {
        base.Initialize(game);
        
    }

    protected override void OnReset(EntityEventData data)
    {
        base.OnReset(data);

        var localPlayer = PlayerManager.Components.FirstOrDefault(p => p.EntityId == 1);
        if (localPlayer != null)
        {
            foreach (var item in SwitchOnWithXpManager.Components)
            {
                if (item.RequiredXp <= localPlayer.XP)
                {
                    item.GetComponent<SwitchPlateTarget>().StartOn = true;
                }
                else
                {
                    item.GetComponent<SwitchPlateTarget>().StartOn = false;
                }
            }
        }

        foreach (var switchPlate in SwitchPlateTargetManager.Components)
        {

            if (switchPlate.On && !switchPlate.StartOn)
            {
                switchPlate.StartCoroutine(RotateAround(switchPlate, 1f, -90));

            }
            switchPlate.On = switchPlate.StartOn;
        }
         
        
         
    }

    protected override void ActivateSwitchPlate(PlateCubeCollsion data, SwitchPlateTrigger switchplatetrigger)
    {
        base.ActivateSwitchPlate(data, switchplatetrigger);

        foreach (var target in SwitchPlateTargetManager.Components.Where(p => p.Register == switchplatetrigger.Register))
        {
            target.StartCoroutine(RotateAround(target, 0.2f, !target.On ? 90 : -90));
            target.On = !target.On;
            
        }
    }


    public IEnumerator RotateAround(SwitchPlateTarget target, float timeInSeconds, float angle)
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
