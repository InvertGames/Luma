using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Invert.ECS;
using Invert.ECS.Unity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class CollisionEventDispatcher : MonoBehaviour
{
    private UnityGame _game;

    public UnityGame Game
    {
        get { return _game ?? (_game = FindObjectOfType<UnityGame>()); }
        set { _game = value; }
    }

    /// <summary>
    /// Send an event, if the object is entering a collision.
    /// </summary>
    /// <param name="collisionInfo">
    /// The <see cref="Collision"/> collision information, reported by Unity.
    /// </param>
    public void OnCollisionEnter(Collision collisionInfo)
    {
        var collider = collisionInfo.gameObject.GetComponent<EntityComponent>();
        if (collider == null) return;
        var entityId = collider.EntityId;
        var collidee = this.GetComponent<EntityComponent>().EntityId;

        this.Game.EventManager.SignalEvent(new EventData(UnityEvents.CollisionEnter, new CollisionEventData() { CollideeId = collidee, ColliderId = entityId }));
    }
    public void OnCollisionExit(Collision collisionInfo)
    {
        var collider = collisionInfo.gameObject.GetComponent<EntityComponent>();
        if (collider == null) return;
        var entityId = collider.EntityId;
        var collidee = this.GetComponent<EntityComponent>().EntityId;

        this.Game.EventManager.SignalEvent(new EventData(UnityEvents.CollisionExit, new CollisionEventData() { CollideeId = collidee, ColliderId = entityId }));
    }
    public void OnCollisionStay(Collision collisionInfo)
    {
        var collider = collisionInfo.gameObject.GetComponent<EntityComponent>();
        if (collider == null) return;
        var entityId = collider.EntityId;
        var collidee = this.GetComponent<EntityComponent>().EntityId;

        this.Game.EventManager.SignalEvent(new EventData(UnityEvents.CollisionStay, new CollisionEventData() { CollideeId = collidee, ColliderId = entityId }));
    }
    public void OnTriggerEnter(Collider collisionInfo)
    {
        var collider = collisionInfo.gameObject.GetComponent<EntityComponent>();
        if (collider == null) return;
        var entityId = collider.EntityId;
        var collidee = this.GetComponent<EntityComponent>().EntityId;

        this.Game.EventManager.SignalEvent(new EventData(UnityEvents.TriggerEnter, new CollisionEventData() { CollideeId = collidee, ColliderId = entityId }));
    }
    public void OnTriggerExit(Collider collisionInfo)
    {
        var collider = collisionInfo.gameObject.GetComponent<EntityComponent>();
        if (collider == null) return;
        var entityId = collider.EntityId;
        var collidee = this.GetComponent<EntityComponent>().EntityId;

        this.Game.EventManager.SignalEvent(new EventData(UnityEvents.TriggerExit, new CollisionEventData() { CollideeId = collidee, ColliderId = entityId }));
    }
    public void OnTriggerStay(Collider collisionInfo)
    {
        var collider = collisionInfo.gameObject.GetComponent<EntityComponent>();
        if (collider == null) return;
        var entityId = collider.EntityId;
        var collidee = this.GetComponent<EntityComponent>().EntityId;

        this.Game.EventManager.SignalEvent(new EventData(UnityEvents.TriggerStay, new CollisionEventData() { CollideeId = collidee, ColliderId = entityId }));
    }
    public void OnMouseDown()
    {
        var entityId = this.GetComponent<EntityComponent>().EntityId;
        this.Game.EventManager.SignalEvent(new EventData(UnityEvents.MouseDown, new MouseEventData() { EntityId = entityId }));
    }
    public void OnMouseUp()
    {
        var entityId = this.GetComponent<EntityComponent>().EntityId;
        this.Game.EventManager.SignalEvent(new EventData(UnityEvents.MouseUp, new MouseEventData() { EntityId = entityId }));
    }
}

public class ButtonEventDispatcher : MonoBehaviour
{
    public Button _Button;

    public void Awake()
    {
        _Button.onClick.AddListener(() =>
        {
            UnityGame.Instance.EventManager.SignalEvent(new EventData()
            {
                EventType = uGUIEvents.Click,
                Data = new UIEventData()
                {
                    EntityId = GetComponent<EntityComponent>().EntityId,
                    Component = _Button,
                    Name = _Button.name
                }
            });
        });
    }
    

}