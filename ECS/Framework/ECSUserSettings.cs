using UnityEngine;

namespace Invert.ECS
{
    public class ECSUserSettings : ScriptableObject
    {
        public int _StartingId;
        public ToolboxAsset[] _Toolboxes;
    }
}