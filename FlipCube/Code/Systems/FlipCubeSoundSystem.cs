using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class FlipCubeSoundSystem : FlipCubeSoundSystemBase {
    
    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
    }
    
    protected override void OnCubeEnter(PlateCubeCollsion data, Plate plateid) {
        base.OnCubeEnter(data, plateid);
        if (CubeEnteredSound != null)
        AudioSource.PlayClipAtPoint(CubeEnteredSound,plateid.transform.position);
    }

    public AudioClip CubeEnteredSound;

    protected override void OnCubeLeft(PlateCubeCollsion data, Plate plateid) {
        base.OnCubeLeft(data, plateid);
        if (CubeExitSound != null)
        AudioSource.PlayClipAtPoint(CubeExitSound, plateid.transform.position);
    }

    public AudioClip CubeFallSound;

    protected override void OnCubeFall(EntityEventData data, Cube entityid) {
        base.OnCubeFall(data, entityid);
        if (CubeFallSound != null)
        AudioSource.PlayClipAtPoint(CubeFallSound, entityid.transform.position);
    }

    public AudioClip CubeExitSound;
    public AudioClip LevelCompleteSound;
    public AudioClip RollCompleteSound;
    public AudioClip RollBeginSound;
    public AudioClip ResetSound;
    
    private float LevelCompleteVolume;

    protected override void GameOver(IEvent e)
    {
        base.GameOver(e);
        //if (LevelCompleteSound != null)
        //AudioSource.PlayClipAtPoint(LevelCompleteSound, Camera.main.transform.position,LevelCompleteVolume);
    }

    protected override void OnComplete(CollisionEventData data, GoalPlate colliderid, Cube collideeid)
    {
        base.OnComplete(data, colliderid, collideeid);
        if (LevelCompleteSound != null)
            AudioSource.PlayClipAtPoint(LevelCompleteSound, Camera.main.transform.position, LevelCompleteVolume);
    }

    protected override void OnRollComplete(RollEventData data)
    {
        base.OnRollComplete(data);
        if (RollCompleteSound != null)
            AudioSource.PlayClipAtPoint(RollCompleteSound, Camera.main.transform.position);
    }

    protected override void OnRollBegin(RollEventData data, Cube entityid)
    {
        base.OnRollBegin(data, entityid);
        if (RollBeginSound != null)
            AudioSource.PlayClipAtPoint(RollBeginSound, Camera.main.transform.position);
    }

    protected override void OnReset(EntityEventData data, Cube entityid)
    {
        base.OnReset(data, entityid);
        if (ResetSound != null)
            AudioSource.PlayClipAtPoint(ResetSound, Camera.main.transform.position);
    }
}
