using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using Invert.ECS.Unity;
using UnityEngine;


// Base class initializes the event listeners.
public class TargetingHUDSystem : TargetingHUDSystemBase {
    
    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
    }
    
    protected override void TargetAcquired(Invert.ECS.IEvent e) {
        HighlightTarget(e);
    }
    
    protected override void HighlightTarget(TargetData data, Targetable targetableid, Int32 targeter) {
        base.HighlightTarget(data, targetableid, targeter);
        Debug.Log("Highlighting Target");
        
    }
    
    protected override void HighlightTarget(Invert.ECS.IEvent e) {
        base.HighlightTarget(e);
    }
}
