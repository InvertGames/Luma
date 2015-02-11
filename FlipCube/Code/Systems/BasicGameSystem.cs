using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


public class BasicGameSystem : BasicGameSystemBase
{
    public BasicGame CurrentGame;

    public ZoneAsset StartingZone;


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
        base.OnFall(e); Delay(2f, () =>
      {
          FlipCubeSystem.SignalResetGame(Game, new EntityEventData());
          CubeInputSystem.SignalSelected(Game, new EntityEventData()
          {
              EntityId = 1
          });
          //LevelSystem.SignalLevelRestart(Game, new LevelEventData()); 
      });
    }

    protected override void GoalPlateHit(IEvent e)
    {
        base.GoalPlateHit(e);

        Delay(1f, () =>
        {
            LevelSystem.SignalLevelComplete(Game, new LevelEventData()
            {
                //LevelId = CurrentLevel.EntityId,
            });

            FlipCubeSystem.SignalBackToZone(Game, new EntityEventData());
        });
    }

    protected override void OnEnteredLevel(LevelEventData data, Level level)
    {
        base.OnEnteredLevel(data, level);
        // Every time we enter a level, reset the game
        FlipCubeSystem.SignalResetGame(Game, new EntityEventData());
        // For now, lets select the cube upon start, the main cube should
        // always have an id of 1
        CubeInputSystem.SignalSelected(Game, new EntityEventData()
        {
            EntityId = 1
        });

        //FlipCubeSystem.SignalResetGame(Game, new EntityEventData());
    }


    protected override void EnteredZone(IEvent e)
    {
        base.EnteredZone(e);
        // Every time we enter a zone, reset the game
        FlipCubeSystem.SignalResetGame(Game, new EntityEventData());
        // For now, lets select the cube upon start, the main cube should
        // always have an id of 1
        CubeInputSystem.SignalSelected(Game, new EntityEventData()
        {
            EntityId = 1
        });

    }

    protected override void GameReady(IEvent e)
    {
        base.GameReady(e);
        if (ZoneManager.Components.Count > 0)
        {
            // We started the zone directly from it's scene for editing purposes
            // make sure that we call zone entered
            ZoneSystem.SignalEnteredZone(Game, new ZoneEventData()
            {
                Zone = ZoneManager.Components[0].Asset,
                ZoneId = ZoneManager.Components[0].EntityId
            });
            return;
        }
        if (LevelManager.Components.Count > 0)
        {
            // We started the level directly from it's scene for editing purposes
            // make sure that we call level entered
            LevelSystem.SignalEnteredLevel(Game, new LevelEventData()
            {
                LevelData = LevelManager.Components[0].Asset,
                LevelId = LevelManager.Components[0].EntityId
            });
            return;
        }

        // We aren't in zone, so lets enter one.
        ZoneSystem.SignalEnterZone(Game, new ZoneEventData()
        {
            Zone = StartingZone
        });

    }
}
