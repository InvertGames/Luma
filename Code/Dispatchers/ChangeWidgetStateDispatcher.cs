using UnityEngine;
using System.Collections;
using FlipCube;
using uFrame.Attributes;
using uFrame.ECS;


[UFrameEventDispatcher("Change UI Widget State"), uFrameCategory("UI Widgets")]
public class ChangeWidgetStateDispatcher : EcsDispatcher {

    public WidgetState State { get; set; }

    void ChangeState(WidgetState state)
    {
        EntityId = Entity.EntityId;
        State = state;
        this.Publish(this);
    }

}

