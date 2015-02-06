using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;


public class PlayerSystem : PlayerSystemBase {
    protected override void ComponentCreated(IEvent e)
    {
        base.ComponentCreated(e);
        var playerComponent = e.Data as Player;
        if (playerComponent != null)
        {
            SignalPlayerLoaded(new PlayerEventData()
            {
                PlayerData = playerComponent,
                PlayerId = playerComponent.EntityId
            });
        }
    }
}
