using UnityEngine;
using System.Collections;
using FlipCube;
using uFrame.Kernel;

public class CloseAllGeneralMenusDispatcher : uFrameComponent {

    public void CloseAllGeneralMenus()
    {
        this.Publish(new CloseAllGeneralMenus());
    }

}
