using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;


public class DemoSystem : DemoSystemBase {
    public override void SignalBoxABCollided(BoxABCollision data)
    {
        base.SignalBoxABCollided(data);
        foreach (var item in BoxAManager.Components)
        {
            
        }

    }
}
