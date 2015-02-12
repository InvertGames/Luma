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
        // Tell the rest of the world the game is ready, this might be
        // delayed in the future in order to load data from a user profile.
        SignalGameDataReady(new GameReadyData()
        {
            Zones = _Zones
        });
        SignalGameReady(new EntityEventData()); 
    }

    protected override void GoalPlateHit(IEvent e)
    {
        base.GoalPlateHit(e);
        Delay(1f, () =>
        {
            LevelSystem.SignalLevelComplete(Game, new LevelEventData()
            {
                LevelId = CurrentLevel.EntityId,
                LevelData = CurrentLevel
            });

           SignalBackToZone(Game, new EntityEventData());
        });
        //LevelSystem.SignalLevelComplete(Game, new LevelEventData());
    }

    protected override void OnFall(IEvent e)
    {
        base.OnFall(e);
        
    }

    /// <summary>
    /// The game needs to reset.  Here we tell every cube to reset its position.  This is standard
    /// flip cube behaviour :)
    /// </summary>
    /// <param name="e"></param>
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

    /// <summary>
    /// When a zone has been entered, this can sometimes be called if starting
    /// from a zone directly in its scene, the enter zone will be called but not
    /// have the "CurrentZone" set yet.
    /// </summary>
    /// <param name="data"></param>
    protected override void OnEnteredZone(ZoneEventData data)
    {
        base.OnEnteredZone(data);
        CurrentZone = data.Zone;

    }

    /// <summary>
    /// When a level has been entered, make sure we know about it and update the
    /// currentlevel property.  This assures that when starting from a level it
    /// is appropriately set in this system.
    /// </summary>
    /// <param name="data"></param>
    protected override void OnEnteredLevel(LevelEventData data)
    {
        base.OnEnteredLevel(data);
        // Double ensure the current level is set
        CurrentLevel = data.LevelData;
        // Only happens when we start directly in a level
        if (CurrentZone == null)
        CurrentZone = _Zones.FirstOrDefault(p => p.Levels.Contains(data.LevelData));
    }
    /// <summary>
    /// Actually handles moving to a zone.
    /// </summary>
    /// <param name="data"></param>
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

        LoadLevelAsync(CurrentZone.name, () =>
        {
            ZoneSystem.SignalEnteredZone(Game, new ZoneEventData()
            {
                Zone = CurrentZone,
                ZoneId = CurrentZone.EntityId
            });
        });
    }

    /// <summary>
    /// Actually handles moving to the next level
    /// </summary>
    /// <param name="data"></param>
    protected override void HandleNextLevel(EntityEventData data)
    {
        base.HandleNextLevel(data);
        var levelIndex = Array.IndexOf(CurrentZone.Levels, CurrentLevel) + 1;

        LevelSystem.SignalEnterLevel(Game, new EnterLevelEventData()
        {
            LevelData = CurrentZone.Levels[levelIndex]
        });

    }
    /// <summary>
    /// Actuall handles moving into a specific level
    /// </summary>
    /// <param name="data"></param>
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
        //Application.LoadLevelAdditive(CurrentLevel.SceneName);
        
        LoadLevelAsync(CurrentLevel.name, () =>
        {
            LevelSystem.SignalEnteredLevel(Game, new LevelEventData()
            {
                LevelId = CurrentLevel.EntityId,
                LevelData = CurrentLevel
            });
        });

    }
    /// <summary>
    /// Navigate back to the current zone.  Usually when you are in a level already
    /// </summary>
    /// <param name="e"></param>
    protected override void BackToZone(IEvent e)
    {
        base.BackToZone(e);
        ZoneSystem.SignalEnterZone(Game, new ZoneEventData()
        {
            Zone = CurrentZone
        });
    }

    /// <summary>
    /// Handles when a "EnterLevelOnEnter" component has been entered "StandingUp"
    /// </summary>
    /// <param name="data"></param>
    /// <param name="enterlevelonenter"></param>
    protected override void HandleEnterLevelOnEnter(PlateCubeCollsion data, EnterLevelOnEnter enterlevelonenter)
    {
        base.HandleEnterLevelOnEnter(data, enterlevelonenter);
        LevelSystem.SignalEnterLevel(Game, new EnterLevelEventData()
        {
            LevelData = enterlevelonenter.Level
        });
  
    }
}
