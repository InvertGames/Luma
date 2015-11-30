using UnityEngine;
using System.Collections;
using FlipCube;
using uFrame.Kernel;

public class UnloadLevelEventDispatcher : uFrameComponent{

    public void UnloadCurrentLevel()
    {
        Debug.Log("Dispatching");
        this.Publish(new FlipCube.UnloadLevel() { Source = 101});
    }


}
