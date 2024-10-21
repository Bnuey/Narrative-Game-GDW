using UnityEditor;
using UnityEngine;

/// <summary>
/// Generic button that can be assigned to different things.
/// To be used temporarily for simple instances
/// when you just need one thing quickly and don't
/// want to bother making an entire editor script
/// </summary>

[CustomEditor(typeof(InspectorButton))]
public class InspectorButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        InspectorButton inspectorButton = (InspectorButton)target;

        if (GUILayout.Button("Raise"))
        {
            inspectorButton.RaiseEvent();
        }

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        DrawDefaultInspector();
    }

}
