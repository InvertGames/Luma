using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;


public class WindowSystem : WindowSystemBase {
    public override void Initialize(IGame game)
    {
        base.Initialize(game);
   
    }

    protected override void OnComponentCreated(IComponent data)
    {
        base.OnComponentCreated(data);
        var window = data as Window;
        if (window != null)
        {
            window.gameObject.SetActive(false);
        }

    }

    protected override void OnLoaded()
    {
        base.OnLoaded();
        foreach (var item in WindowManager.Components)
        {
            item.gameObject.SetActive(false);
        }
    }

    protected override void HandleShowWindow(WindowEventData data)
    {
        base.HandleShowWindow(data);
        var window = WindowManager.Components.FirstOrDefault(p => p.WindowType == data.Window);
        if (window != null)
        {
            window.gameObject.SetActive(!window.gameObject.activeSelf);
        }
    }
}
