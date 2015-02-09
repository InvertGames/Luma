using UnityEngine;

namespace Invert.ECS.Unity
{
    [ExecuteInEditMode]
    public class EntityComponent : MonoBehaviour,IEntityComponent
    {
        public ToolboxAsset _Toolbox;
       

        [SerializeField]
        private int _EntityId;

        public int EntityId
        {
            get { return _EntityId; }
            set { _EntityId = value; }
        }

        public void Awake()
        {
            var instance = UnityGame.Instance;
            if (instance != null)
            {
                if (instance.EntityManager.EnsureUniqueEntityId(this))
                {
                    // If there is a new id we need to assign it to each UnityComponent on 
                    // this game object
                    foreach (var component in GetComponents<UnityComponent>())
                    {
                        component.EntityId = _EntityId;
                    }
                }
            }
        }
    }

    public class ProxyComponent : EntityComponent, IProxyComponent
    {
        
    }
    public class EntityComponentContainer
    {
        
    }
}