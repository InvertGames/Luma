using UnityEngine;
using System.Collections;
using FlipCube;
using uFrame.ECS;
using uFrame.Kernel;

public class UnloadLevelEventDispatcher : uFrameComponent{

    public void UnloadCurrentLevel()
    {
        this.Publish(new FlipCube.DeconstructScene()
        {
            SceneInstance = LevelManagementSystem.Instance.CurrentActiveLevel.EntityId,
            DeconstructDependencies = true
        });
    }


}
