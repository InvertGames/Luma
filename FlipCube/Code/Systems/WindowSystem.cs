using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;


public class WindowSystem : WindowSystemBase {
    protected override void HandleShowWindow(WindowEventData data)
    {
        base.HandleShowWindow(data);
        var window = WindowManager.Components.FirstOrDefault(p => p.WindowType == data.Window);
        if (window != null)
        {
            window.gameObject.SetActive(true);
        }
    }
}
