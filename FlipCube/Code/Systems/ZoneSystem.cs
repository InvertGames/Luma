using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;


public class ZoneSystem : ZoneSystemBase
{
    public Zone _Zones;
    
    protected override void ComponentCreated(IEvent e)
    {
        base.ComponentCreated(e);
        var zone = e.Data as Zone;
        if (zone != null)
        {
            SignalEnteredZone(new ZoneEventData()
            {
                ZoneId = zone.EntityId
            });
        }
    }
    
}
