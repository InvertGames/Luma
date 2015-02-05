using System.Collections;
using System.Linq;
using UnityEngine;

namespace Invert.ECS.Unity
{
    [RequireComponent(typeof(EntityComponent))]
    public class UnityComponent : MonoBehaviour, IComponent
    {

        public bool _AutoAssignId = true;

        [SerializeField]
        private int _entityId;
        
        public int EntityId
        {
            get { return _entityId; }
            set { _entityId = value; }
        }

        public void Awake()
        {
            if (_AutoAssignId)
            {
                var entityId = GetComponent<EntityComponent>();
                EntityId = entityId.EntityId;
            }

        }
        private bool _registered;
        public void OnEnable()
        {
        
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
            if (!_registered)
            {
                var game = UnityGame.Instance;
                game.ComponentSystem.RegisterComponentInstance(this.GetType(), this);
            }
            
        }
        public void OnDisable()
        {
            //var game = FindObjectOfType<UnityGame>();
            //game.ComponentSystem.RegisterComponentInstance(this.GetType(), this);
        }
       
    }
}