using UnityEngine;

namespace Invert.ECS.Unity
{
    /// <summary>
    /// The Entity Component serves as an identifier for a game-object.  It has two purposes:
    /// 1. Supplying the EntityId to other components at design time.
    /// 2. Helping dispatchers know what entity to signal events for.
    /// 
    /// Assigning Ids:
    /// The Custom Inspector for EntityComponent has two buttons.
    /// Assign New Id - This will incremement your UserSettings "StartingId" and assign the value to this entity and any components that live on the same object.
    /// Assign New To Children - This is nothing more than a convenience option.  If you are adding multiple game-object as children to this game-object then you can
    /// easily assign new id's to its children.  This can be very beneficial in level building scenarios.
    /// </summary>
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