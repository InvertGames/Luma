using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class PlateSystem : PlateSystemBase
{

    public override void Initialize(Invert.ECS.IGame game)
    {
        base.Initialize(game);
    }


    

    //protected override void OnGoalPlate(PlateCubeCollsion data, Plate plate, Cube cube, GoalPlate goalplate)
    //{
    //    base.OnGoalPlate(data, plate, cube, goalplate);
    //    //cube.StartCoroutine(WaitForSecondsRoutine(1f, () =>
    //    //{
    //    //    SignalGoalPlateHit(new PlateCubeCollsion() { CubeId = cube.EntityId, PlateId = plate.EntityId });
    //    //    plate.GetComponent<BoxCollider>().enabled = true;
    //    //}));
    //}

    protected override void DisableColliderCollsion(PlateCubeCollsion data, DisableColliderOnCollision disablecollideroncollision)
    {
        base.DisableColliderCollsion(data, disablecollideroncollision);
        disablecollideroncollision.GetComponent<Collider>().enabled = false;
    }

    public IEnumerator WaitForSecondsRoutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action();
    }
}
