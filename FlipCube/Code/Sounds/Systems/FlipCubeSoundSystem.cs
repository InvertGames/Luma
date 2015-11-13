using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DarkTonic.MasterAudio;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class FlipCubeSoundSystem : FlipCubeSoundSystemBase
{
    public PlaylistController _PlaylistController;

    public override void Initialize(IGame game) {
        base.Initialize(game);
        
    }
    
    protected override void OnCubeEnter(PlateCubeCollsion data, Plate plateid) {
        base.OnCubeEnter(data, plateid);

    }

    protected override void OnCubeLeft(PlateCubeCollsion data, Plate plateid) {
        base.OnCubeLeft(data, plateid);
        
    }

    protected override void OnCubeFall(EntityEventData data, Cube entityid) {
        base.OnCubeFall(data, entityid);
        MasterAudio.PlaySound("Fail");
    }

    protected override void OnComplete(CollisionEventData data, GoalPlate colliderid, Cube collideeid)
    {
        base.OnComplete(data, colliderid, collideeid);
        MasterAudio.PlaySound("Win");
    }

    protected override void OnCubeMoved(MoveCubeData data)
    {
        base.OnCubeMoved(data);
        MasterAudio.PlaySound("Landed");
    }

    protected override void OnRollComplete(RollEventData data)
    {
        base.OnRollComplete(data);
        MasterAudio.PlaySound("Move");
    }

    protected override void OnTeliporting(EntityEventData data)
    {
        base.OnTeliporting(data);
        MasterAudio.PlaySound("Disappear");
    }

    protected override void OnRollBegin(RollEventData data, Cube entityid)
    {
        base.OnRollBegin(data, entityid);
    }

    protected override void OnReset(EntityEventData data, Cube entityid)
    {
        base.OnReset(data, entityid);

    }
}
