using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using Invert.ECS.Unity;
using UnityEngine;


public class DestructionSystem : DestructionSystemBase {
    
    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
    }

    protected override void HandleCollider(CollisionEventData data, Damageable colliderid)
    {
        base.HandleCollider(data, colliderid);
        colliderid.Health -= 10;
    }

    protected override void HandleCollision(CollisionEventData data, Damageable collidee)
    {
        base.HandleCollision(data, collidee);
        collidee.Health -= 10;
    }
}
