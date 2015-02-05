using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Invert.ECS.Unity
{
    public class UnityGame : MonoBehaviour, IGame
    {
        public static UnityGame Instance { get; set; }

        public UnityComponentSystem ComponentSystem;
        private IEventManager _eventManager;
        private readonly LinkedList<ISystem> _systems = new LinkedList<ISystem>();
        public UnitySystem[] _UnitySystems;
        public void AddSystems(ISystem[] systems)
        {
            foreach (var system in systems.OrderBy(p=>p.Priority))
            {
                _systems.AddLast(system);
            }
        }
        public void AddSystem(ISystem system)
        {
            _systems.AddLast(system);
        }

        IComponentSystem IGame.ComponentSystem
        {
            get { return ComponentSystem; }
        }

        public IEventManager EventManager
        {
            get { return _eventManager ?? (_eventManager = new EventManager()); }
            set { _eventManager = value; }
        }

        IEventManager IGame.EventManager
        {
            get { return EventManager; }
        }

        public virtual void System()
        {
            
        }

        public virtual void Awake()
        {
            Instance = this;
            //var systems = new List<ISystem>();
            //foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
            //{
            //    foreach (var type in item.GetTypes())
            //    {
            //        if (typeof (SystemBase).IsAssignableFrom(type))
            //        {
            //            var instance = Activator.CreateInstance(type) as ISystem;
            //            systems.Add(instance);
            //        }
            //    }
              
            //}
            //AddSystems(systems.ToArray());
            //if (_UnitySystems != null) 
            //    AddSystems(_UnitySystems.Cast<ISystem>().ToArray());
            //foreach (var item in _systems)
            //{
            //    //Debug.Log(item.GetType().Name + " Initialized");
            //    item.Initialize(this);
            //}
            foreach (var item in _UnitySystems)
            {
                if (item == null) continue;
                item.Initialize(this);
            }
        }
        public virtual void Start()
        {
            this.EventManager.SignalEvent(new EventData(FrameworkEvents.Loaded, null));
        }

        public virtual void Update()
        {
            //foreach (var item in _systems)
            //{
            //    if (item is UnitySystem) continue;
            //    item.Update();
            //}
        }
    }
}