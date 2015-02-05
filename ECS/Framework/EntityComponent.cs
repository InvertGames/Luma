using UnityEngine;

namespace Invert.ECS.Unity
{
    public class EntityComponent : MonoBehaviour
    {
        [SerializeField]
        private int _EntityId;

        public int EntityId
        {
            get { return _EntityId; }
            set { _EntityId = value; }
        }

        public void UpdateAll()
        {
            
        }
    }

    public class EntityComponentContainer
    {
        
    }
}