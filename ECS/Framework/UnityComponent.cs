using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Invert.ECS.Unity
{
    [RequireComponent(typeof(EntityComponent))]
    public class UnityComponent : MonoBehaviour, IComponent
    {
        public void Reset()
        {
            var entityComponent = this.gameObject.GetComponent<EntityComponent>();
            if (entityComponent != null)
            {
                this.EntityId = entityComponent.EntityId;
            }
        }
        public bool _AutoAssignId = true;

        [SerializeField]
        private int _entityId;
        
        public int EntityId
        {
            get { return _entityId; }
            set { _entityId = value; }
        }

        public virtual void Awake()
        {
            if (_AutoAssignId)
            {
                var entityId = GetComponent<EntityComponent>();
                EntityId = entityId.EntityId;
            }
            var game = UnityGame.Instance;
            if (game != null)
            {

                game.ComponentSystem.RegisterComponentInstance(this.GetType(), this);
                _registered = true;
            }
        }
        private bool _registered;
        public void OnEnable()
        {
#if (UNITY_EDITOR)
            if (!Application.isPlaying)
                return;
#endif
            if (_registered) return;
            var game = UnityGame.Instance;
            if (game != null)
            {
          
                game.ComponentSystem.RegisterComponentInstance(this.GetType(), this);
                _registered = true;
            }
            
            
        }

        public void Start()
        {
#if (UNITY_EDITOR)
            if (!Application.isPlaying)
                return;
#endif
            if (!_registered)
            {
                var game = UnityGame.Instance;
                game.ComponentSystem.RegisterComponentInstance(this.GetType(), this);
                _registered = true;
            }
            
        }
        public void OnDisable()
        {
//#if (UNITY_EDITOR)
//            if (!Application.isPlaying)
//            return;
//#endif
//            if (!_registered) return;
//            var game = UnityGame.Instance;
//            if (game != null)
//            {
//                game.ComponentSystem.DestroyComponentInstance(this.GetType(), this);
//                _registered = false;
//            }
        }

        public void OnDestroy()
        {
#if (UNITY_EDITOR)
            if (!Application.isPlaying)
                return;
#endif
            if (!_registered) return;
            var game = UnityGame.Instance;
            if (game != null)
            {
                game.ComponentSystem.DestroyComponentInstance(this.GetType(), this);
                _registered = false;
            }
        }
       
    }
}