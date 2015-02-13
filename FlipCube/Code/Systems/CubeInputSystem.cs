using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using UnityEngine;


// Base class initializes the event listeners.
public class CubeInputSystem : CubeInputSystemBase {
    
    public override void Initialize(IGame game) {
        base.Initialize(game);
    }

    protected override void TriggerMoveDirectionOnEnter(PlateCubeCollsion data, Cube cube, MoveDirectionOnEnter movedirectiononenter,
        Rollable rollable)
    {
        base.TriggerMoveDirectionOnEnter(data, cube, movedirectiononenter, rollable);
        switch (movedirectiononenter.MoveDirection)
        {
            case CubeMoveDirection.Forward:
                SignalF(new EntityEventData() { EntityId = rollable.EntityId });
                break;
            case CubeMoveDirection.Right:
                SignalR(new EntityEventData() { EntityId = rollable.EntityId });
                break;
            case CubeMoveDirection.Left:
                SignalL(new EntityEventData() { EntityId = rollable.EntityId });
                break;
            case CubeMoveDirection.Backwards:
                SignalB(new EntityEventData() { EntityId = rollable.EntityId });
                break;
        }
    }

    public override void Update()
    {
        base.Update();
        if (Selected == null) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SignalL(Selected);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SignalR(Selected);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SignalB(Selected);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SignalF(Selected);
        }
    }

    protected override void HandleMouseDown(MouseEventData data, Cube entityid)
    {
        base.HandleMouseDown(data, entityid);
        
        SignalSelected(new EntityEventData() {EntityId = entityid.EntityId});
    }

    protected override void HandleSelection(EntityEventData data, Cube entityid)
    {
        base.HandleSelection(data, entityid);
        Selected = data;
    }

    public EntityEventData Selected { get; set; }


}
