using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class LevelSystem : LevelSystemBase {
    
    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
    }

    protected override void OnNextLevel(int data)
    {
        base.OnNextLevel(data);
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    protected override void OnCollideWith(CollisionEventData data, LevelCompleteOnContact collideeid)
    {
        base.OnCollideWith(data, collideeid);
        SignalLevelComplete(collideeid.EntityId);
    }

    protected override void FailCollision(CollisionEventData data, FailOnCollision colliderid)
    {
        base.FailCollision(data, colliderid);
        SignalLevelFailed(0);
    }

    protected override void RestartCollision(CollisionEventData data, RestartOnCollision colliderid)
    {
        base.RestartCollision(data, colliderid);
        SignalRestartLevel(0);
    }

    protected override void OnMouseDownRestart(MouseEventData data, RestartOnMouseDown entityid)
    {
        base.OnMouseDownRestart(data, entityid);
        SignalRestartLevel(0);
    }
}
