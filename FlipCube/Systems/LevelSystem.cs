using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class LevelSystem : LevelSystemBase {
    protected override void ComponentCreated(IEvent e)
    {
        base.ComponentCreated(e); 
        var level = e.Data as Level;
        if (level != null)
        {
            SignalEnteredLevel(new LevelEventData()
            {
                LevelId = level.EntityId
            });
            
        }
    }
}
