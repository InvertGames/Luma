using System;
using System.Collections;
using UnityEngine;

namespace Invert.ECS
{
    using System.Collections.Generic;
    public class EntityEventData : object
    {
        public Int32 EntityId { get; set; }
    }
    public class MouseEventData : object
    {
        public Int32 EntityId { get; set; }
        public Vector2 ScreenPoint { get; set; }

    }
    public interface IEntityManager
    {
        int GetUniqueEntityId();
        void SpawnEntity();

    }

    public enum FrameworkEvents
    {
        ComponentCreated,

        Loaded,
        ComponentDestroyed
    }
    public class EntityManager
    {
        
    }

    public abstract class ComponentManager
    {
        public void RegisterComponent(IComponent item)
        {
           AddItem(item);
        }

        public void UnRegisterComponent(IComponent item)
        {
            RemoveItem(item);
        }

        protected abstract void AddItem(IComponent component);
        protected abstract void RemoveItem(IComponent component);
    }
    public class ComponentManager<TComponentType> : ComponentManager where TComponentType : IComponent
    {
        private List<TComponentType> _items;

        public List<TComponentType> Components
        {
            get { return _items ?? (_items = new List<TComponentType>()); }
            set { _items = value; }
        }

        protected override void AddItem(IComponent component)
        {
            Components.Add((TComponentType)component);
        }

        protected override void RemoveItem(IComponent component)
        {
            Components.Remove((TComponentType)component);
        }
    }

    public class SystemManager
    {
   
        
    }

    public enum SystemEvents
    {
        Loaded
    }

    public interface ISystem
    {
        int Priority { get;  }
        IGame Game { get; set; }

        void Initialize(IGame game);
        void Destroy();

        void Update();

    }

    public interface IGame
    {
        IComponentSystem ComponentSystem { get; }
        IEventManager EventManager { get;  }
    }

    public interface IComponentSystem
    {
        bool TryGetComponent<TComponent>(int entityId, out TComponent component) where TComponent : class, IComponent;
        bool TryGetComponent<TComponent>(int[] entityIds, out TComponent[] component) where TComponent : class, IComponent;
        IEnumerable<TComponent> GetAllComponents<TComponent>() where TComponent : IComponent;
        ComponentManager<TComponent> RegisterComponent<TComponent>() where TComponent : IComponent;
    }

    public interface IEventManager
    {
        Action ListenFor(object eventType, EventHandlerDelegate handler);
        void StopListeningFor(object eventType, EventHandlerDelegate handler);
        void SignalEvent(IEvent e);
        void QueueEvent(IEvent e);
        void SignalQueued();
    }

    public class EventManager : IEventManager
    {
        private Dictionary<object, List<EventHandlerDelegate>> _handlers;

        private Dictionary<object, List<EventHandlerDelegate>> Handlers
        {
            get { return _handlers ?? (_handlers = new Dictionary<object, List<EventHandlerDelegate>>()); }
            set { _handlers = value; }
        }

        public List<Action> QueuedEvents { get; set; }

        public Action ListenFor(object eventType, EventHandlerDelegate handler)
        {
            List<EventHandlerDelegate> existing;
            if (!Handlers.TryGetValue(eventType, out existing))
            {
                Handlers[eventType] = existing =  new List<EventHandlerDelegate>();
            }
            existing.Add(handler);
            return () => { StopListeningFor(eventType, handler); };
        }

        public void StopListeningFor(object eventType, EventHandlerDelegate handler)
        {
            List<EventHandlerDelegate> existing;
            if (!Handlers.TryGetValue(eventType, out existing))
            {           
                Handlers[eventType] = existing = new List<EventHandlerDelegate>();
            }
            existing.Remove(handler);
        }

        public void SignalEvent(IEvent e)
        {
            //UnityEngine.Debug.Log(e.EventType + " was signaled");
            List<EventHandlerDelegate> existing;
            if (!Handlers.TryGetValue(e.EventType, out existing))
            {
                Handlers[e.EventType] = existing = new List<EventHandlerDelegate>();
            }
            for (var i = 0; i < existing.Count; i++)
            {   
                existing[i](e);
            }
          
        }

        public void QueueEvent(IEvent e)
        {
            QueuedEvents.Add(()=>{ SignalEvent(e);});
        }

        public void SignalQueued()
        {
            var queue = QueuedEvents.ToArray();
            QueuedEvents.Clear();
            foreach (var item in queue)
            {
                item();
            }
        }

    }
    
    public interface IComponent
    {
        int EntityId { get; set; }
    }
    
    public delegate void EventHandlerDelegate(IEvent data );

    public interface IEvent
    {
        object EventType { get; set; }
        object Data { get; set; }

    }

    public class EventData : IEvent
    {
        public EventData()
        {
        }

        public EventData(object eventType, object data)
        {
            EventType = eventType;
            Data = data;
        }

        public object EventType { get; set; }

        public object Data { get; set; }
    }

    public class SystemBase : ISystem
    {
        public int Priority
        {
            get { return 0; }
        }

        public IGame Game { get; set; }
        public virtual void Initialize(IGame game)
        {
            this.Game = game;
        }

        public virtual void Destroy()
        {

        }

        public virtual void Update()
        {

        }
    }
}

// Unity Stuff
namespace Invert.ECS
{
    using UnityEngine;
    using Invert.ECS;

    public enum UnityEvents
    {
        MouseDown,
        MouseUp,
        CollisionEnter, 
        CollisionExit,
        CollisionStay,
        TriggerEnter,
        TriggerExit,
        TriggerStay
    }
    public class UnitySystem : MonoBehaviour, ISystem
    {
        public int Priority
        {
            get { return 0; }
        }
        public IGame Game { get; set; }
        public virtual void Initialize(IGame game)
        {
            Game = game;
        }

        public virtual void Destroy()
        {
           
        }

        public virtual void Update()
        {
           
        }
        public void Delay(float seconds, Action action)
        {
            StartCoroutine(WaitForSecondsRoutine(seconds, action));
        }
        public IEnumerator WaitForSecondsRoutine(float seconds, Action action)
        {
            yield return new WaitForSeconds(seconds);
            action();
        }
    }
    public class CollisionEventData : object
    {

        private Int32 _colliderId;

        private Int32 _collideeId;

        public Int32 ColliderId
        {
            get
            {
                return _colliderId;
            }
            set
            {
                _colliderId = value;
            }
        }

        public Int32 CollideeId
        {
            get
            {
                return _collideeId;
            }
            set
            {
                _collideeId = value;
            }
        }
    }

}