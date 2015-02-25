using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class SpecialFXSystem : SpecialFXSystemBase
{

    public GameObject CubeLandedEffect;
    public GameObject TeliportingEffect;
    public GameObject SpawnEffect;
    public GameObject GoalEffect;
    protected override void OnGoalPlate(PlateCubeCollsion data, GoalPlate goalplate)
    {
        base.OnGoalPlate(data, goalplate);
        if (GoalEffect != null)
        {
            Instantiate(GoalEffect, goalplate.transform.position, Quaternion.identity);
        }
    }

    protected override void OnCubeReset(EntityEventData data, Cube cube)
    {
        base.OnCubeReset(data, cube);
        Delay(1f, () =>
        {
            if (SpawnEffect != null)
            {
                Instantiate(SpawnEffect, cube.transform.position + (Vector3.down), Quaternion.identity);
            }
        });
       
    }

    protected override void OnTeliporting(EntityEventData data, Teliporter teliporter)
    {
        base.OnTeliporting(data, teliporter);
        if (TeliportingEffect != null)
        {
            Instantiate(TeliportingEffect, teliporter.transform.position, Quaternion.identity);
        }
    }

    protected override void OnReset(EntityEventData data)
    {
        base.OnReset(data);
        //foreach (var item in TweenPlateColorsManager.Components)
        //{
        //    item.renderer.material.color = item.IdleColor;
        //}
    }

    protected override void OnCubeEntered(PlateCubeCollsion data, Plate plate)
    {
        base.OnCubeEntered(data, plate);
        Instantiate(CubeLandedEffect, plate.transform.position, Quaternion.identity);
    }

    protected override void OnCubeLeft(PlateCubeCollsion data, Plate plate)
    {
        base.OnCubeLeft(data, plate);

    }

    protected override void TweenPlateOff(PlateCubeCollsion data, TweenPlateColors tweenplatecolors)
    {
        base.TweenPlateOff(data, tweenplatecolors);
        if (!tweenplatecolors.IsToggle)
        {
            tweenplatecolors.renderer.material.colorTo(1f, tweenplatecolors.IdleColor);
        }
        //tweenplatecolors.renderer.material.colorTo(2f, tweenplatecolors.IdleColor);
    }

    protected override void TweenPlateOn(PlateCubeCollsion data, TweenPlateColors tweenplatecolors)
    {
        base.TweenPlateOn(data, tweenplatecolors);
        if (tweenplatecolors.IsToggle)
        {
            if (tweenplatecolors.IsOn)
            {
                tweenplatecolors.renderer.material.colorTo(0.1f, tweenplatecolors.IdleColor);
                tweenplatecolors.IsOn = false;

            }
            else
            {
                tweenplatecolors.renderer.material.colorTo(0.1f, tweenplatecolors.OnEnterColor);
                tweenplatecolors.IsOn = true;
            }

        }
        else
        {
            tweenplatecolors.renderer.material.colorTo(0.1f, tweenplatecolors.OnEnterColor);    
        }
        
        
    }

    //protected override void OnCubeEntered(PlateCubeCollsion data, Plate plateid)
    //{
    //    base.OnCubeEntered(data, plateid);
    //    Instantiate(CubeLandedEffect, plateid.transform.position, Quaternion.identity);
    //}

    //protected override void OnCubeLeft(PlateCubeCollsion data, Plate plateid)
    //{
    //    base.OnCubeLeft(data, plateid);
     

    //}
}
