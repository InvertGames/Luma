using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Invert.ECS.Unity
{
    public class UnityComponentSystem : MonoBehaviour, IComponentSystem
    {
        public UnityGame Game;
        private Dictionary<Type, ComponentManager> _componentManager;
        public LinkedList<Component> Components { get; set; }

        public Dictionary<System.Type, ComponentManager> ComponentManagers
        {
            get { return _componentManager ?? (_componentManager = new Dictionary<Type, ComponentManager>()); }
            set { _componentManager = value; }
        }
        public void RegisterComponentInstance(Type componentType, IComponent instance)
        {
            ComponentManager existing;
            if (!ComponentManagers.TryGetValue(componentType, out existing))
            {
                var type = typeof (ComponentManager<>).MakeGenericType(componentType);
                existing = Activator.CreateInstance(type) as ComponentManager;
                ComponentManagers.Add(componentType, existing);
            }
            existing.RegisterComponent(instance);
            Game.EventManager.SignalEvent(new EventData(FrameworkEvents.ComponentCreated,instance));

        }
        public void DestroyComponentInstance(Type componentType, IComponent instance)
        {
            ComponentManager existing;
            if (!ComponentManagers.TryGetValue(componentType, out existing))
            {
                return;
            }
            existing.UnRegisterComponent(instance);
            //Game.EventManager.SignalEvent(new EventData(FrameworkEvents.ComponentDestroyed, instance));

        }
        public ComponentManager<TComponent> RegisterComponent<TComponent>() where TComponent : IComponent
        {
            ComponentManager existing;
            if (!ComponentManagers.TryGetValue(typeof (TComponent), out existing))
            {
                existing = new ComponentManager<TComponent>();
                ComponentManagers.Add(typeof(TComponent), existing);
                return (ComponentManager<TComponent>) existing;
            }
            else
            {
                return (ComponentManager<TComponent>)existing;
            }
           
        }

        public bool TryGetComponent<TComponent>(int[] entityIds, out TComponent[] components) where TComponent : class, IComponent
        {
            var list = new List<TComponent>();
            foreach (var entityid in entityIds)
            {
                TComponent component;
                if (!TryGetComponent(entityid, out component))
                {
                    components = null;
                    return false;
                }
                list.Add(component);
            }
            components = list.ToArray();
            return true;
        }

        public IEnumerable<T> GetAllComponents<T>() where T : IComponent
        {
            ComponentManager existing;
            if (ComponentManagers.TryGetValue(typeof(T), out existing))
            {
                var manager = (ComponentManager<T>) existing;
                foreach (var item in manager.Components)
                    yield return (T)item;

            }
            else
            {
                yield break;
            }
        }
        public bool TryGetComponent<TComponent>(int entityId, out TComponent component) where TComponent : class, IComponent
        {
            ComponentManager existing;
            if (!ComponentManagers.TryGetValue(typeof(TComponent), out existing))
            {
                component = null;
                return false;
            }
            var manager = (ComponentManager<TComponent>) existing;
            var result = manager.Components.FirstOrDefault(p => p.EntityId == entityId) as TComponent;
            if (result != null)
            {
                component = result;
                return true;
            }
            component = null;
            return false;
        }
    }
    
}