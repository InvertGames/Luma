using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class SwitchPlateSystem : SwitchPlateSystemBase {
    
    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
        
    }

    protected override void LevelRestart(IEvent e)
    {
        base.LevelRestart(e);
        //foreach (var switchPlate in SwitchPlateTargetManager.Components)
        //{
        //    if (switchPlate.On && !switchPlate.StartOn)
        //    {
        //        switchPlate.StartCoroutine(RotateAround(switchPlate, 1f, -90));

        //    }
        //    switchPlate.On = switchPlate.StartOn;

        //}
    }

    protected override void Loaded(IEvent e)
    {
        base.Loaded(e);
        //foreach (var switchPlate in SwitchPlateTargetManager.Components)
        //{
        //    if (!switchPlate.StartOn )
        //    {
        //        switchPlate.StartCoroutine(RotateAround(switchPlate, 1f, -90));

        //    }
        //    switchPlate.On = switchPlate.StartOn;

        //}
    }
    
    protected override void RollCompletedStandingUp(Invert.ECS.IEvent e) {
        base.RollCompletedStandingUp(e);
    }

    protected override void ActivateSwitchPlate(PlateCubeCollsion data, SwitchPlateTrigger plateid, SwitchPlateTarget[] targets)
    {
        base.ActivateSwitchPlate(data, plateid, targets);
        foreach (var target in targets)
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
    protected override void ActivateSwitchPlate(Invert.ECS.IEvent e) {
        base.ActivateSwitchPlate(e);
    }
}
