using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public class FlipCubeSystem : FlipCubeSystemBase
{
    protected override void Loaded(IEvent e)
    {
        base.Loaded(e);
        SignalGameReady(new EntityEventData());
    }

    protected override void HandleEnterZone(ZoneEventData data)
    {
        base.HandleEnterZone(data);
        foreach (var item in LevelManager.Components)
        {
            Destroy(item.gameObject);
        }
        Application.LoadLevelAdditive(data.SceneName);
    }

    protected override void GoalPlateHit(IEvent e)
    {
        base.GoalPlateHit(e);
        //LevelSystem.SignalLevelComplete(Game, new LevelEventData());
    }

    protected override void OnFall(IEvent e)
    {
        base.OnFall(e);
        
    }

    protected override void ResetGame(IEvent e)
    {
        base.ResetGame(e);
        foreach (var cube in CubeManager.Components)
        {
            CubeSystem.SignalReset(Game, new EntityEventData()
            {
                EntityId = cube.EntityId
            });
        }
    }

    protected override void HandleEnterLevel(EnterLevelEventData data)
    {
        base.HandleEnterLevel(data);
        foreach (var item in ZoneManager.Components)
        {
            DestroyImmediate(item.gameObject);
        }
        
        Application.LoadLevelAdditive(data.SceneName);
        
    }

    protected override void HandleEnterLevelOnEnter(PlateCubeCollsion data, EnterLevelOnEnter enterlevelonenter)
    {
        base.HandleEnterLevelOnEnter(data, enterlevelonenter);
        LevelSystem.SignalEnterLevel(Game, new EnterLevelEventData()
        {
            SceneName = enterlevelonenter.SceneName
        });
  
    }
}
