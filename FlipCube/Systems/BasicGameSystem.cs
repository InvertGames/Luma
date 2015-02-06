using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public class BasicGameSystem : BasicGameSystemBase
{
    public BasicGame CurrentGame;
    
    public string StartingZoneName = "ZoneA";

    protected override void ComponentCreated(IEvent e)
    {
        base.ComponentCreated(e);
        var game = e.Data as BasicGame;
        if (game != null)
        {
            CurrentGame = game;
        }
    }

    protected override void OnFall(IEvent e)
    {
        base.OnFall(e);
        FlipCubeSystem.SignalResetGame(Game, new EntityEventData());
        //LevelSystem.SignalLevelRestart(Game, new LevelEventData());
    }

    protected override void GoalPlateHit(IEvent e)
    {
        base.GoalPlateHit(e);
        Delay(1f, () =>
        {
            LevelSystem.SignalLevelComplete(Game, new LevelEventData()
            {
                LevelId = CurrentLevel.EntityId,
            });
             
        });
    }
    public Level CurrentLevel { get; set; }
    protected override void OnEnteredLevel(LevelEventData data, Level level)
    {
        base.OnEnteredLevel(data, level);
        CurrentLevel = level;
        FlipCubeSystem.SignalResetGame(Game, new EntityEventData());
    }

    protected override void EnteredLevel(IEvent e)
    {
        base.EnteredLevel(e);
        
    }
    
    protected override void EnteredZone(IEvent e)
    {
        base.EnteredZone(e);
        FlipCubeSystem.SignalResetGame(Game, new EntityEventData());
     
    }

    protected override void GameReady(IEvent e)
    {
        base.GameReady(e);
        if (ZoneManager.Components.Count > 0) return;
        if (LevelManager.Components.Count > 0) return;
        
        //if (Level.Components.Count > 0) return;

        ZoneSystem.SignalEnterZone(Game, new ZoneEventData()
        {
            SceneName = StartingZoneName
        });
    }
}
