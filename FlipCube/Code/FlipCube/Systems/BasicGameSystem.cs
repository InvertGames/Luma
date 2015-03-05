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

    }

    protected override void OnFall(IEvent e)
    {
      base.OnFall(e);
      Delay(2f, () =>
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

    public override void Update()
    {
        base.Update();
        
    }

    protected override void OnRoll(RollEventData data, Player player)
    {
        base.OnRoll(data, player);
        player.TotalFlips++;
        
        var level = LevelManager.Components.FirstOrDefault(p => p.EntityId == player.CurrentLevelId);
        if (level != null)
        {
            level.MovesTaken++;
            var max = level.MinimumMoves*4f;
            var v = max - level.MovesTaken;
            if (v >= (level.MinimumMoves * 3))
            {
                level.CurrentStatus = LevelProgressStatus.Perfect;
            }
            else if (v >= (level.MinimumMoves * 2))
            {
                level.CurrentStatus = LevelProgressStatus.Good;
            }
            else if (v >= (level.MinimumMoves * 1))
            {
                level.CurrentStatus = LevelProgressStatus.Bad;
            }
            else 
            {
                level.CurrentStatus = LevelProgressStatus.Fair;
            }
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
        var gainedXp = (max - badXp) / (level.TimesPlayed + 1);

        if (level.CurrentStatus < level.BestStatus || level.TimesPlayed == 0)
        {
            level.BestStatus = level.CurrentStatus;
        }
        var time = Convert.ToInt32(level.CurrentTime.TotalSeconds);
        if (time < level.BestTime || level.BestTime == 0)
        {
            gainedXp += Mathf.RoundToInt(gainedXp*0.2f);
            level.BestTime = time;
        }
        level.TimesPlayed++;


        foreach (var player in PlayerManager.Components)
        {
            PlayerSystem.SignalAddXp(Game, new PlayerExperienceData()
            {
                PlayerId = player.EntityId,
                XP = gainedXp
            });
        }
        PlayerDataSystem.SignalSaveGame(Game, new SaveGameEventData());
    }

    protected override void OnEnteredLevel(LevelEventData data, Level level)
    {
        base.OnEnteredLevel(data, level);
        level.StartTime = DateTime.Now;
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
