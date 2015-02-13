using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using Invert.ECS.Unity;


// Base class initializes the event listeners.
public class TargetingSystem : TargetingSystemBase {
    
    public override void Initialize(IGame game) {
        base.Initialize(game);
    }
    
    protected override void OnCollisionEnter(Invert.ECS.IEvent e) {
        TargetableInRange(e);
    }
    
    protected override void TargetableInRange(CollisionEventData data, Targetable targetable, Targeter targeter) {
        base.TargetableInRange(data, targetable, targeter);
        
        targeter.Target = targetable.EntityId;

        Game.EventManager.SignalEvent(new EventData(TargetingEvents.TargetAcquired,new TargetData()
        {
            Targeter = targeter.EntityId,
            TargetableId = targetable.EntityId
        }));
    }
    
    protected override void TargetableInRange(Invert.ECS.IEvent e) {
        base.TargetableInRange(e);
    }
}
