using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public class FlipCubeSystem : FlipCubeSystemBase
{

    public ZoneAsset[] _Zones;

    private ZoneAsset CurrentZone;

    private LevelAsset CurrentLevel;

    protected override void Loaded(IEvent e)
    {
        base.Loaded(e);
        SignalGameReady(new EntityEventData()); 
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

    protected override void HandleEnterZone(ZoneEventData data)
    {
        base.HandleEnterZone(data);
        
        CurrentZone = data.Zone;

        foreach (var item in ZoneManager.Components.ToArray())
        {
            Destroy(item.gameObject);
        }
        foreach (var item in LevelManager.Components.ToArray())
        {
            Destroy(item.gameObject);
        }
        
        Application.LoadLevelAdditive(CurrentZone.SceneName);
    }

    protected override void HandleNextLevel(EntityEventData data)
    {
        base.HandleNextLevel(data);
        var levelIndex = Array.IndexOf(CurrentZone.Levels, CurrentLevel) + 1;

        LevelSystem.SignalEnterLevel(Game, new EnterLevelEventData()
        {
            LevelData = CurrentZone.Levels[levelIndex]
        });

    }

    protected override void HandleEnterLevel(EnterLevelEventData data)
    {
        base.HandleEnterLevel(data);
        foreach (var item in ZoneManager.Components.ToArray())
        {
            Destroy(item.gameObject);
        }
        foreach (var item in LevelManager.Components.ToArray())
        {
            Destroy(item.gameObject);
        }
        CurrentLevel = data.LevelData;
        Application.LoadLevelAdditive(CurrentLevel.SceneName);
        
    }

    protected override void BackToZone(IEvent e)
    {
        base.BackToZone(e);
        ZoneSystem.SignalEnterZone(Game, new ZoneEventData()
        {
            Zone = CurrentZone
        });
    }

    protected override void HandleEnterLevelOnEnter(PlateCubeCollsion data, EnterLevelOnEnter enterlevelonenter)
    {
        base.HandleEnterLevelOnEnter(data, enterlevelonenter);
        LevelSystem.SignalEnterLevel(Game, new EnterLevelEventData()
        {
    
            LevelData = enterlevelonenter.Level
        });
  
    }
}
