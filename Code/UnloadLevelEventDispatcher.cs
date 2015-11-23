using UnityEngine;
using System.Collections;
using FlipCube;
using uFrame.Kernel;

public class UnloadLevelEventDispatcher : uFrameComponent{

    public void UnloadCurrentLevel()
    {
        this.Publish(new FlipCube.UnloadLevel() { Source = 101});
    }


}
