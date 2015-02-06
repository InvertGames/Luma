using UnityEngine;
using System.Collections;
using Invert.ECS.Unity;
using UnityEditor;

[CustomEditor(typeof(EntityComponent))]
public class EntityComponentEditor : Editor {
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
}

public static class IdHelpers
{
    [MenuItem("GameObject/ECS/Generate New Id's For Children")]
    public static void NewIdsForChildren()
    {
      
    }
}