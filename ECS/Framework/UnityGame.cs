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
        public string[] _BackgroundScenes;
        private IEntityManager _entityManager;

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

        public IEntityManager EntityManager
        {
            get { return _entityManager ?? (_entityManager = new EntityManager()); }
            set { _entityManager = value; }
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
            StartCoroutine(LoadSystems());
        }

        public IEnumerator LoadSystems()
        {
            this.SignalProgress("Loading Scenes", 0.1f);
            for (int index = 0; index < _SystemScenes.Length; index++)
            {
                var systemScene = _SystemScenes[index];
                this.SignalProgress("Loading " + systemScene, 0.2f * index);
                AsyncOperation operation = Application.LoadLevelAdditiveAsync(systemScene);
                while (!operation.isDone)
                {
#if UNITY_EDITOR
                    yield return new WaitForSeconds(1f);
#endif
                    yield return new WaitForEndOfFrame();
                }
            }
            for (int index = 0; index < _UnitySystems.Length; index++)
            {
                var item = _UnitySystems[index];
                item.Initialize(this);
                this.SignalProgress("Initializing " + item.name, 0.1f * index);
                yield return new WaitForEndOfFrame();
            }

            var asyncSystems = FindObjectsOfType<UnitySystem>();
            for (int index = 0; index < asyncSystems.Length; index++)
            {
                var s = asyncSystems[index];
                if (_UnitySystems.Contains(s)) continue;
                Debug.Log(string.Format("Loaded {0} system", s.name));
                s.Initialize(this);
                this.SignalProgress("Initializing " + s.name, 0.1f * index);
                yield return new WaitForEndOfFrame();
            }

            for (int index = 0; index < _BackgroundScenes.Length; index++)
            {
                var backgroundScene = _BackgroundScenes[index];
               
                AsyncOperation operation = Application.LoadLevelAdditiveAsync(backgroundScene);
                while (!operation.isDone)
                {
#if UNITY_EDITOR
                    yield return new WaitForSeconds(3f);
#endif
                    this.SignalProgress("Loading " + backgroundScene, operation.progress);
                    yield return new WaitForEndOfFrame();
                }
            }
  

            yield return new WaitForEndOfFrame();
            this.EventManager.SignalEvent(new EventData(FrameworkEvents.Loaded, null));
            this.SignalProgress("Complete", 1f);
        }
    
    }

    public static class GameSignals
    {
        public static void SignalProgress(this IGame game, string message, float progress)
        {
            game.EventManager.SignalEvent(new EventData(FrameworkEvents.LoadingProgress, new LoadingProgressData()
            {
                Message = message,
                Progress = progress
            }));
        }
    }
}