using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;
using UnityEngine.EventSystems;


// Base class initializes the event listeners.
public class TeliporterSystem : TeliporterSystemBase {
    protected override void HandleCollision(PlateCubeCollsion data, Cube cube, Teliporter teliporter)
    {
        base.HandleCollision(data, cube, teliporter);
        var targetPlate = TeliporterTargetManager.Components.FirstOrDefault(p => p.Register == teliporter.Register);

        CubeSystem.SignalMoveTo(Game, new MoveCubeData() { CubeId = cube.EntityId, Position = targetPlate.transform.position });
    }

}
