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

    protected override void SplitCube(PlateCubeCollsion data, YingYangPlate yingyangplate, Cube cube, Plate plateA)//, Plate plateB)
    {
        base.SplitCube(data, yingyangplate, cube, plateA);//, plateB);
        CubeSystem.SignalSplitCube(Game, new SplitCubeData()
        {
            CubeId = cube.EntityId,
            TargetPositionA = plateA.transform.position,
            //TargetPositionB = plateB.transform.position
        });
    }

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
