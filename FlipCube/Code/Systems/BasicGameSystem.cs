using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;

public class BasicGameSystem : BasicGameSystemBase
{
    public BasicGame CurrentGame;

    protected override void ComponentCreated(IEvent e)
    {
        base.ComponentCreated(e);
        var game = e.Data as BasicGame;
        if (game != null)
        {
            CurrentGame = game;
        }
        var level = e.Data as Level;
        if (level != null)
        {
            var spawnPoint = LevelSpawnPointManager.Components.FirstOrDefault(p => p._Level.EntityId == level.EntityId);
            if (spawnPoint != null)
            {
                level.transform.parent = spawnPoint.transform;
                level.transform.localPosition = new Vector3(0f, 0f, 0f);
                Debug.Log("Moved to spawn point");
            }

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
          CubeSystem.SignalMoveTo(Game, new MoveCubeData()
          {
              CubeId = 1,
              Position = LastSpawnPosition
          });
          //LevelSystem.SignalLevelRestart(Game, new LevelEventData()); 
      });
    }

    protected override void OnReset(EntityEventData data)
    {
        base.OnReset(data);
        // Reset the moves taken to 0
        foreach (var level in LevelManager.Components)
        {
            level.MovesTaken = 0;
        }
    }

    protected override void OnRoll(RollEventData data)
    {
        base.OnRoll(data);
        foreach (var level in LevelManager.Components)
        {
            level.MovesTaken++;
        }
    }

    protected override void OnLevelComplete(LevelEventData data, Level level)
    {
        base.OnLevelComplete(data, level);
        var max = data.LevelData.MaxXP;

        var minMoves = data.LevelData.MinimumMoves;
        var badXpMoves = level.MovesTaken - minMoves;
        var xpPerStep = max / minMoves;
        var badXp = badXpMoves * xpPerStep;
        var gainedXp = max - badXp;
        level.TimesPlayed++;
        foreach (var player in PlayerManager.Components)
        {
            PlayerSystem.SignalAddXp(Game, new PlayerExperienceData()
            {
                PlayerId = player.EntityId,
                XP = gainedXp
            });
        }
        PlayerDataSystem.SignalSaveGame(Game, new EntityEventData());
    }

    protected override void OnEnteredLevel(LevelEventData data, Level level)
    {
        base.OnEnteredLevel(data, level);

//        LastSpawnPosition = level.SpawnPoint == null ? level.transform.GetChild(0).transform.position : level.SpawnPoint.position;
        // Every time we enter a level, reset the game
        FlipCubeSystem.SignalResetGame(Game, new EntityEventData());
        // For now, lets select the cube upon start, the main cube should
        // always have an id of 1
        CubeInputSystem.SignalSelected(Game, new EntityEventData()
        {
            EntityId = 1
        });
        CubeSystem.SignalMoveTo(Game, new MoveCubeData()
        {
            CubeId = 1,
            Position = LastSpawnPosition
        });
        //FlipCubeSystem.SignalResetGame(Game, new EntityEventData());
    }

    public Vector3 LastSpawnPosition { get; set; }

    protected override void EnteredZone(IEvent e)
    {
        base.EnteredZone(e);
        // Every time we enter a zone, reset the game
        FlipCubeSystem.SignalResetGame(Game, new EntityEventData());
        // For now, lets select the cube upon start, the main cube should
        // always have an id of 1
        // SignalMoveTo(new MoveCubeData() { CubeId = 1, Position = Vector3.zero });

        CubeInputSystem.SignalSelected(Game, new EntityEventData()
        {
            EntityId = 1
        });
        CubeSystem.SignalMoveTo(Game, new MoveCubeData() { CubeId = 1, Position = Vector3.zero });
    }

    protected override void GameReady(IEvent e)
    {
        base.GameReady(e);

        //Zone zone;
        var zone = ZoneManager.Components.FirstOrDefault(p => p.SceneName == Application.loadedLevelName);

        if (zone != null)
        {
            // We started the zone directly from it's scene for editing purposes
            // make sure that we call zone entered
            ZoneSystem.SignalEnteredZone(Game, new ZoneEventData()
            {
                Zone = zone
            });
            return;
        }

        var level = LevelManager.Components.FirstOrDefault(p => p.SceneName == Application.loadedLevelName);
        if (level != null)
        {
            // We started the level directly from it's scene for editing purposes
            // make sure that we call level entered
            LevelSystem.SignalEnteredLevel(Game, new LevelEventData()
            {
                LevelData = level,
                LevelId = level.EntityId
            });
            return;
        }

        // We aren't in zone, so lets enter one.
        ZoneSystem.SignalEnterZone(Game, new ZoneEventData()
        {
            Zone = ZoneManager.Components.FirstOrDefault(p=>p.SceneName == "ZoneA")
        });

    }
}
