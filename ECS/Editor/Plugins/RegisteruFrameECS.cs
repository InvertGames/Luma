using Invert.Common;
using Invert.Common.UI;
using Invert.Core;
using Invert.ECS.Unity;
using UnityEditor;
using UnityEngine;

namespace Invert.ECS.Graphs
{
    [InitializeOnLoad]
    public class RegisteruFrameECS
    {
       

        [UnityEditor.MenuItem("Assets/uFrameECS/Create Toolbox",false)]
        public static void CreateToolboxAsset()
        {
            uFrameMenu.CreateAsset<ToolboxAsset>();
        }
        [UnityEditor.MenuItem("Assets/uFrameECS/Create User", false)]
        public static void CreateUserAsset()
        {
            uFrameMenu.CreateAsset<ECSUserSettings>();
        }
        static RegisteruFrameECS()
        {
            InvertApplication.CachedAssemblies.Add(typeof(uFrameECS).Assembly);
            InvertApplication.CachedAssemblies.Add(typeof(ISystem).Assembly);
            //SceneView.onSceneGUIDelegate -= OnSceneGuiDelegate;
            //SceneView.onSceneGUIDelegate += OnSceneGuiDelegate;
        }

    }
}