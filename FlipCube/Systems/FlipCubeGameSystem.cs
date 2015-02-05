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
    public override void Initialize(Invert.ECS.IGame game) {
        base.Initialize(game);
    }

    protected override void Loaded(IEvent e)
    {
        base.Loaded(e);
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
        LevelSystem.SignalRestartLevel(Game,0);
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
        LevelSystem.SignalNextLevel(Game, 0);
    }
    public IEnumerator DelayedRestart()
    {
        yield return new WaitForSeconds(3f);
        LevelSystem.SignalRestartLevel(Game,0);
    }
    protected override void OnRestart(int data)
    {
        base.OnRestart(data);
        foreach (var component in Game.ComponentSystem.GetAllComponents<Rollable>())
        {
            Game.EventManager.SignalEvent(new EventData(CubeSystemEvents.Reset,new EntityEventData()
            {
                EntityId = component.EntityId
            }));
            
        }
        
      
    }
}
