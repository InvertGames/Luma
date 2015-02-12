using UnityEngine;
using System.Collections;
using Invert.Common;
using Invert.Common.UI;
using Invert.ECS;
using Invert.ECS.Graphs;
using Invert.ECS.Unity;
using UnityEditor;

[CustomEditor(typeof(EntityComponent))]
public class EntityComponentEditor : Editor
{
    private static ECSUserSettings _userSettings;
    public static ECSUserSettings UserSettings
    {
        get { return uFrameECS.UserSettings; }
    }

    public static bool ReplaceMode { get; set; }
    public static KeyCode LastKeyCode;
    public static bool IsMouseDown { get; set; }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        //serializedObject.Update();
        serializedObject.Update();
        if (UserSettings == null)
        {
            EditorGUILayout.HelpBox("User Setting is not defined.", MessageType.Warning);

        }
        else
        {
            if (GUILayout.Button("Assign New Id"))
            {
                var t = target as EntityComponent;
                UserSettings._StartingId++;
                t.SetEntityId(UserSettings._StartingId);
            }
            //if (GUILayout.Button("Assign To All"))
            //{
            //    var t = target as EntityComponent;
            //    foreach (var component in t.GetComponents<UnityComponent>())
            //    {
            //        component.EntityId = t.EntityId;
            //        EditorUtility.SetDirty(component);
            //    }
            //}
            if (GUILayout.Button("Assign New To Children"))
            {
                var t = target as EntityComponent;
                for (var i = 0; i < t.transform.childCount; i++)
                {
                    var child = t.transform.GetChild(i);
                    var entityComponent = child.GetComponent<EntityComponent>();
                    UserSettings._StartingId++;
                    entityComponent.SetEntityId(UserSettings._StartingId);
                }
            }
        }
       
        serializedObject.ApplyModifiedProperties();
    }
    public virtual void OnSceneGUI()
    {
        var settings = UserSettings;
        if (settings == null)
        {
            return;
        }
        //var t = target as EntityComponent;
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
        var width = 105;
        // var transform = t.transform;
        Handles.BeginGUI();
        GUI.Box(new Rect(0, 0, width, Screen.height), string.Empty, ElementDesignerStyles.Background);
        GUILayout.BeginVertical(GUILayout.Width(width));

        foreach (var toolbox in settings._Toolboxes)
        {
            if (GUIHelpers.DoToolbarEx(toolbox.name))
            {

                foreach (var prefab in toolbox._ToolboxPrefabs)
                {
                
                    DoPrefabButton(prefab, width, 35);
                    GUILayout.Label(prefab.name, ElementDesignerStyles.SubHeaderStyle);
                    if (LastSelectedPrefab == null)
                    {
                        LastSelectedPrefab = prefab;
                        //LastEntityComponent = t;
                    }
                }
            }
        }


        //transform = transform.parent;
        //if (transform != null)
        //    t = transform.GetComponent<EntityComponent>();


        ReplaceMode = GUILayout.Toggle(ReplaceMode, "Replace");
        if (IsShiftDown)
        {
            GUILayout.Label("Quick Add On", EditorStyles.boldLabel);
            //QuickAddIfItShould();
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
                        AddPrefab(LastSelectedPrefab);
                    }
                };
                Selection.activeGameObject.SendMessage("ToolbarAddQuick", args, SendMessageOptions.DontRequireReceiver);
                if (args.ShouldAdd)
                {
                    AddPrefab(LastSelectedPrefab);
                }
            }
        }

    }

    public static bool IsShiftDown { get; set; }
    protected static void DoPrefabButton(GameObject prefab,int width, int height)
    {
        var oldAlignment = ElementDesignerStyles.EventButtonLargeStyle.alignment;
        var oldPadding = ElementDesignerStyles.EventButtonLargeStyle.padding;
        ElementDesignerStyles.EventButtonLargeStyle.alignment = TextAnchor.MiddleCenter;
        ElementDesignerStyles.EventButtonLargeStyle.padding = new RectOffset(0,0,3,3);
        if (GUILayout.Button(new GUIContent(AssetPreview.GetAssetPreview(prefab)) { tooltip = prefab.name }, ElementDesignerStyles.EventButtonLargeStyle, GUILayout.Width(width), GUILayout.Height(height)))
        {

            AddPrefab(prefab);
            LastSelectedPrefab = prefab;
        }
        ElementDesignerStyles.EventButtonLargeStyle.alignment = oldAlignment;
        ElementDesignerStyles.EventButtonLargeStyle.padding = oldPadding;
    }

    protected static void AddPrefab(GameObject prefab)
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
                    UserSettings._StartingId++;
                    entityComponent.EntityId = UserSettings._StartingId;
                    EditorUtility.SetDirty(UserSettings);
                }

            }
            Object.DestroyImmediate(Selection.activeGameObject);
        }
        else
        {
            if (Selection.activeGameObject != null)
            {
                go.transform.parent = Selection.activeGameObject.transform.parent;
                if (go.transform.parent == null)
                {
                    go.transform.parent = Selection.activeGameObject.transform;
                }
            }
                

            

            UserSettings._StartingId++;
            entityComponent.EntityId = UserSettings._StartingId;
            EditorUtility.SetDirty(UserSettings);
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
    public static GameObject LastSelectedPrefab { get; set; }

  
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
        serializedObject.Update();
        EditorGUILayout.PropertyField(property);
        serializedObject.ApplyModifiedProperties(); base.OnInspectorGUI();
        

    }

}

public static class IdHelpers
{
    [MenuItem("GameObject/ECS/Generate New Id's For Children")]
    public static void NewIdsForChildren()
    {

    }
}