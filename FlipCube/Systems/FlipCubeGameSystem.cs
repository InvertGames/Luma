using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class FlipCubeGameSystem : FlipCubeGameSystemBase
{
    public int StartingCubeId;

    public int CurrentZoneId;

    protected override void OnEnteredZone(ZoneEventData data)
    {
        base.OnEnteredZone(data);
        Cube cube;
        if (Game.ComponentSystem.TryGetComponent(StartingCubeId, out cube))
        {
            Game.EventManager.SignalEvent(new EventData(CubeSystemEvents.Reset, new EntityEventData()
            {
                EntityId = StartingCubeId
            }));
            Game.EventManager.SignalEvent(new EventData(CubeInputSystemEvents.Selected, new EntityEventData()
            {
                EntityId = StartingCubeId
            }));
        }
    }

    protected override void OnEnterZone(ZoneEventData data, Zone zone)
    {
        base.OnEnterZone(data, zone);
        //Application.LoadLevelAdditive(zone.SceneName);
        ZoneSystem.SignalEnteredZone(Game,data);
    }

    protected override void Loaded(IEvent e)
    {
        base.Loaded(e);
        ZoneSystem.SignalEnterZone(Game, new ZoneEventData()
        {
            ZoneId = CurrentZoneId
        });
        //LevelSystem.SignalRestartLevel(Game, new LevelEventData(0));
    }

    protected override void OnFail(IEvent @event)
    {
        base.OnFail(@event);

        StartCoroutine(DelayedRestart());
    }

    protected override void GameOver(IEvent e)
    {
        base.GameOver(e);
        StartCoroutine(NextLevel());
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        //LevelSystem.SignalEnterLevel(Game, 0);
    }
    public IEnumerator DelayedRestart()
    {
        yield return new WaitForSeconds(3f);
//        LevelSystem.SignalRestartLevel(Game,0);
    }

    protected override void OnRestart(LevelEventData data)
    {
        base.OnRestart(data);
        foreach (var component in Game.ComponentSystem.GetAllComponents<Rollable>())
        {
            Game.EventManager.SignalEvent(new EventData(CubeSystemEvents.Reset, new EntityEventData()
            {
                EntityId = component.EntityId
            }));
        }
    }
}
