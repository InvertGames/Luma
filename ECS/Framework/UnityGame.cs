using System;
using System.Collections;
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
        public string[] _SystemScenes;

        public void AddSystems(ISystem[] systems)
        {
            foreach (var system in systems.OrderBy(p => p.Priority))
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
            foreach (var item in _UnitySystems)
            {
                item.Initialize(this);
            }
        }
        private IEnumerator Start()
        {
            foreach (var systemScene in _SystemScenes)
            {
                AsyncOperation operation = Application.LoadLevelAdditiveAsync(systemScene);
                while (!operation.isDone)
                {
                    yield return new WaitForEndOfFrame();
                }

            }
            var asyncSystems = FindObjectsOfType<UnitySystem>();
            foreach (var s in asyncSystems)
            {
                if (_UnitySystems.Contains(s)) continue;
                Debug.Log(string.Format("Loaded {0} system", s.name));
                s.Initialize(this);
            }
            yield return new WaitForEndOfFrame();
            this.EventManager.SignalEvent(new EventData(FrameworkEvents.Loaded, null));
        }
    }
}