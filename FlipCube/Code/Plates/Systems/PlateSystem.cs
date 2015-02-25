using UnityEngine;


// Base class initializes the event listeners.
public class PlateSystem : PlateSystemBase
{
    protected override void SplitCube(PlateCubeCollsion data, YingYangPlate yingyangplate, Cube cube, Plate[] plate)
    {
        base.SplitCube(data, yingyangplate, cube, plate);
        CubeSystem.SignalSplitCube(Game, new SplitCubeData()
        {
            CubeId = cube.EntityId,
            TargetPositionA = plate[0].transform.position,
            TargetPositionB = plate[1].transform.position
        });
    }


    protected override void DisableColliderCollsion(PlateCubeCollsion data, DisableColliderOnCollision disablecollideroncollision)
    {
        base.DisableColliderCollsion(data, disablecollideroncollision);
        disablecollideroncollision.GetComponent<Collider>().enabled = false;

    }
}
