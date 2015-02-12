using UnityEngine;

namespace Invert.ECS
{
    public class ECSUserSettings : ScriptableObject
    {
        public int _StartingId;
        public ToolboxAsset[] _Toolboxes;

        public int GetUniqueId()
        {
            _StartingId++;
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
#endif
            return _StartingId;
        }
    }
}