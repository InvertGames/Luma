using UnityEngine;

namespace Invert.ECS.Unity
{
    [ExecuteInEditMode]
    public class EntityComponent : MonoBehaviour,IEntityComponent
    {
        [SerializeField]
        private int _EntityId;

        public int EntityId
        {
            get { return _EntityId; }
            set
            {
                _EntityId = value;
                
            }
        }

        public void SetEntityId(int id)
        {
            this.EntityId = id;
            foreach (var item in this.GetComponents<UnityComponent>())
            {
                item.EntityId = id;
#if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(item);
                UnityEditor.EditorUtility.SetDirty(this);
#endif
            }
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