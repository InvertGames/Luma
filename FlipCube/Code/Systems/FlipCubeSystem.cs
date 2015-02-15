using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public class FlipCubeSystem : FlipCubeSystemBase
{

    //public ZoneAsset[] _Zones;

    private Zone CurrentZone;
    private Level CurrentLevel;

    protected override void Loaded(IEvent e)
    {
        base.Loaded(e);
        // Tell the rest of the world the game is ready, this might be
        // delayed in the future in order to load data from a user profile.
        SignalGameDataReady(new GameReadyData()
        {
            LocalPlayer = PlayerManager.Components.FirstOrDefault(p=>p.EntityId == 1)
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
        {
            Zone zone;
            if (Game.ComponentSystem.TryGetComponent(data.LevelData.EntityId, out zone))
            {
                CurrentZone = zone;
            }
        }
    }
    /// <summary>
    /// Actually handles moving to a zone.
    /// </summary>
    /// <param name="data"></param>
    protected override void HandleEnterZone(ZoneEventData data)
    {
        base.HandleEnterZone(data);
        
        CurrentZone = data.Zone;

        CurrentZone.IsCurrent = true;
        foreach (var item in ZoneSceneManager.Components.ToArray())
        {
            Destroy(item.gameObject);
        }
        foreach (var item in LevelSceneManager.Components.ToArray())
        {
            Destroy(item.gameObject);
        }

        foreach (var player in PlayerManager.Components)
        {
            player.CurrentZoneId = data.Zone.EntityId;
        }

        LoadLevelAsync(CurrentZone.SceneName, () =>
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
            LevelData = CurrentZone.Levels[levelIndex],
            
        });

    }
    /// <summary>
    /// Actuall handles moving into a specific level
    /// </summary>
    /// <param name="data"></param>
    protected override void HandleEnterLevel(EnterLevelEventData data)
    {
        base.HandleEnterLevel(data);
        foreach (var item in ZoneSceneManager.Components.ToArray())
        {
             Destroy(item.gameObject);
        }
        foreach (var item in LevelSceneManager.Components.ToArray())
        {
            Destroy(item.gameObject);
        }
        CurrentLevel = data.LevelData;
        // Move each player into it
        foreach (var player in PlayerManager.Components)
        {
            player.CurrentLevelId = CurrentLevel.EntityId;
        }

        LoadLevelAsync(CurrentLevel.SceneName, () =>
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


    protected override void HandleEnterLevelOnEnter(PlateCubeCollsion data, EnterLevelOnEnter enterlevelonenter, Level level)
    {
        base.HandleEnterLevelOnEnter(data, enterlevelonenter, level);
        LevelSystem.SignalEnterLevel(Game, new EnterLevelEventData()
        {
            LevelData = level
        });
    }
}
