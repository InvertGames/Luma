using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using Invert.Core;
using Invert.Core.GraphDesigner;
using Invert.ECS.Graphs;
using Invert.ECS.Unity;
using UnityEditor;
using Object = UnityEngine.Object;

public class FlipCubePlugin : DiagramPlugin, ICreateAssetListener {
    public override void Initialize(uFrameContainer container)
    {
        
    }

    public void AssetCreated(Type assetType, object asset)
    {
        if (assetType == typeof(LevelAsset))
        {
            var levelAsset = asset as LevelAsset;
            var levelPath = AssetDatabase.GetAssetPath(levelAsset);
            if (EditorApplication.SaveCurrentSceneIfUserWantsTo())
            {
                
            }
            EditorApplication.NewScene();
            var go = new GameObject("Level");
            var entity = go.AddComponent<EntityComponent>();
            var level = go.AddComponent<Level>();
            var startUp = go.AddComponent<LoadStartup>();
            startUp.SystemSceneName = "Game";

            entity.SetEntityId(levelAsset.EntityId);
            level.Asset = levelAsset;
            EditorUtility.SetDirty(startUp);
            EditorUtility.SetDirty(level);
            EditorUtility.SetDirty(go);
            Object.DestroyImmediate(Camera.main.gameObject);
            EditorApplication.SaveScene(levelPath.Replace(".asset", ".unity"));
            Selection.activeGameObject = go;
        }
        if (assetType == typeof(ZoneAsset))
        {
            var zoneAsset = asset as ZoneAsset;
            var zonePath = AssetDatabase.GetAssetPath(zoneAsset);
            if (EditorApplication.SaveCurrentSceneIfUserWantsTo())
            {

            }
            EditorApplication.NewScene();
            var go = new GameObject("Zone");
            var entity = go.AddComponent<EntityComponent>();
            var zone = go.AddComponent<Zone>();
            var startUp = go.AddComponent<LoadStartup>();
            startUp.SystemSceneName = "Game";

            entity.SetEntityId(zoneAsset.EntityId);
            zone.Asset = zoneAsset;
            EditorUtility.SetDirty(startUp);
            EditorUtility.SetDirty(zone);
            EditorUtility.SetDirty(go);
            Object.DestroyImmediate(Camera.main.gameObject);
            EditorApplication.SaveScene(zonePath.Replace(".asset", ".unity"));
            Selection.activeGameObject = go;
        }
    }
}
