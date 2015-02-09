using UnityEngine;
using System.Collections;
using Invert.ECS;
using Invert.ECS.Unity;
using UnityEditor;

[CustomEditor(typeof(EntityComponent))]
public class EntityComponentEditor : Editor
{
    public static bool ReplaceMode { get; set; }
    public static KeyCode LastKeyCode;
    public static bool IsMouseDown { get; set; }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //serializedObject.Update();
        serializedObject.Update();
        if (GUILayout.Button("Assign To All"))
        {
            var t = target as EntityComponent;
            foreach (var component in t.GetComponents<UnityComponent>())
            {
                component.EntityId = t.EntityId;
                EditorUtility.SetDirty(component);
            }
        }
        if (GUILayout.Button("Assign New To Children"))
        {
            var t = target as EntityComponent;
            for (var i = 0; i < t.transform.childCount; i++)
            {
                var child = t.transform.GetChild(i);
                var entityComponent = child.GetComponent<EntityComponent>();

                if (entityComponent != null)
                {
                    entityComponent.EntityId = t.EntityId + i + 1;
                    foreach (var component in entityComponent.GetComponents<UnityComponent>())
                    {
                        component.EntityId = entityComponent.EntityId;
                        EditorUtility.SetDirty(component);
                    }
                    EditorUtility.SetDirty(entityComponent);

                }
            }
        }
        serializedObject.ApplyModifiedProperties();
    }
    public virtual void OnSceneGUI()
    {
        var t = target as EntityComponent;
        var e = Event.current;
        if (e.isMouse && e.type == EventType.MouseDown)
        {
            IsMouseDown = true;
        }
        if (e.isMouse && e.type == EventType.MouseUp)
        {
            IsMouseDown = false;
        }
        
        if (e.isKey && e.type == EventType.KeyUp)
        {
            if (e.keyCode == KeyCode.M && !IsMouseDown)
            {
                IsShiftDown = !IsShiftDown;
            }

            //if (e.keyCode == KeyCode.M)
            //    IsShiftDown = false;

            LastKeyCode = e.keyCode;
            if (LastKeyCode == KeyCode.R)
            {
                ReplaceMode = !ReplaceMode;
            }

            if (!IsMouseDown)
                e.Use();
        }

        var transform = t.transform;
        Handles.BeginGUI();
        GUILayout.BeginVertical(GUILayout.Width(50));

        while (transform != null)
        {
            if (t != null)
            {
                if (t._Toolbox != null && t._Toolbox._ToolboxPrefabs != null)
                {
                    foreach (var prefab in t._Toolbox._ToolboxPrefabs)
                    {
                        DoPrefabButton(prefab, t);
                        if (LastSelectedPrefab == null)
                        {
                            LastSelectedPrefab = prefab;
                            LastEntityComponent = t;
                        }
                    }

                }


            }
            transform = transform.parent;
            if (transform != null)
                t = transform.GetComponent<EntityComponent>();
        }

        ReplaceMode = GUILayout.Toggle(ReplaceMode, "Replace Mode");
        if (IsShiftDown)
        {
            GUILayout.Label("Quick Add On", EditorStyles.boldLabel);
            QuickAddIfItShould();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        Handles.EndGUI();
        //GUILayout.EndArea();
    }

    public static EntityComponent LastEntityComponent { get; set; }

    private void QuickAddIfItShould()
    {
        if (Event.current.isKey && Event.current.type == EventType.KeyUp && IsShiftDown && !ReplaceMode)
        {
            if (Selection.activeGameObject != null)
            {
                var args = new ToolbarArgs()
                {
                    IsReplacement = false,
                    IsShiftKey = true,
                    LastKeyPressed = LastKeyCode,
                    SelectedObject = LastSelectedPrefab,
                    ShouldAdd = false,
                    AddAction = () =>
                    {
                        AddPrefab(LastSelectedPrefab, LastEntityComponent);
                    }
                };
                Selection.activeGameObject.SendMessage("ToolbarAddQuick", args, SendMessageOptions.DontRequireReceiver);
                if (args.ShouldAdd)
                {
                    AddPrefab(LastSelectedPrefab,LastEntityComponent);
                }
            }
        }

    }

    public static bool IsShiftDown { get; set; }

    protected virtual void DoPrefabButton(GameObject prefab, EntityComponent t)
    {

        if (GUILayout.Button(new GUIContent(AssetPreview.GetAssetPreview(prefab)) { tooltip = prefab.name }, GUILayout.Width(50), GUILayout.Height(50)))
        {

            AddPrefab(prefab, t);
            LastSelectedPrefab = prefab;
            LastEntityComponent = t;
        }
    }

    public static GameObject LastSelectedPrefab { get; set; }

    protected virtual void AddPrefab(GameObject prefab, EntityComponent t)
    {

        var go = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
        var entityComponent = go.GetComponent<EntityComponent>();
        if (Selection.activeGameObject != null && ReplaceMode)
        {
            var position = Selection.activeGameObject.transform.position;
            var rotation = Selection.activeGameObject.transform.rotation;
            go.transform.parent = Selection.activeGameObject.transform.parent;
            go.transform.position = position;
            go.transform.rotation = rotation;

            if (entityComponent != null)
            {
                var selectedEntityComponent = Selection.activeGameObject.GetComponent<EntityComponent>();
                if (selectedEntityComponent != null)
                {

                    entityComponent.EntityId = selectedEntityComponent.EntityId;
                }
                else
                {
                    t._Toolbox._StartingId++;
                    entityComponent.EntityId = t._Toolbox._StartingId;
                    EditorUtility.SetDirty(t._Toolbox);
                }

            }
            DestroyImmediate(Selection.activeGameObject);
        }
        else
        {
            go.transform.parent = t.transform;
            t._Toolbox._StartingId++;
            entityComponent.EntityId = t._Toolbox._StartingId;
            EditorUtility.SetDirty(t._Toolbox);
        }


        if (entityComponent != null)
        {
            foreach (var item in entityComponent.GetComponentsInChildren<UnityComponent>())
            {
                item.EntityId = entityComponent.EntityId;
                EditorUtility.SetDirty(item);
            }
        }
        if (!ReplaceMode)
        {
            go.SendMessage("ToolbarAdd", new ToolbarArgs()
            {
                SelectedObject = Selection.activeGameObject,
                LastKeyPressed = LastKeyCode,
                IsReplacement = ReplaceMode
            }, SendMessageOptions.DontRequireReceiver);
        }

        Selection.activeGameObject = go;
        Undo.RegisterCreatedObjectUndo(go, "Add " + prefab.name);


        AssetDatabase.SaveAssets();
    }
}

[CustomEditor(typeof(EntityComponent))]
public class PlateEditor : EntityComponentEditor
{

    public override void OnSceneGUI()
    {
        base.OnSceneGUI();

    }
}


[CustomEditor(typeof(UnityComponent), true)]
public class ComponentEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var property = serializedObject.FindProperty("_Asset");
        if (property != null)
        {
            if (property.objectReferenceValue == null)
            {
                base.OnInspectorGUI();
            }
            else
            {
                serializedObject.Update();
                EditorGUILayout.PropertyField(property);
                serializedObject.ApplyModifiedProperties();
            }
        }
        else
        {
            base.OnInspectorGUI();
        }

    }

}

public static class IdHelpers
{
    [MenuItem("GameObject/ECS/Generate New Id's For Children")]
    public static void NewIdsForChildren()
    {

    }
}