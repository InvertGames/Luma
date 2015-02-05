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

    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
    }

    protected override void RestartLevel(IEvent e)
    {
        base.RestartLevel(e);
        foreach (var tweenComponent in TweenPlateColorsManager.Components)
        {
            tweenComponent.renderer.material.colorTo(0.1f, tweenComponent.IdleColor);
        }
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
