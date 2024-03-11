using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NPCDataSO))]
public class NPCDataSOEditor : Editor
{
    private SerializedProperty _npcName;
    private SerializedProperty _canDialog;
    private SerializedProperty _dialogNodeGraph;

    private void OnEnable()
    {
        _npcName = serializedObject.FindProperty("NpcName");
        _canDialog = serializedObject.FindProperty("CanDialog");
        _dialogNodeGraph = serializedObject.FindProperty("DialogNodeGraph");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(_npcName);
        EditorGUILayout.PropertyField(_canDialog);

        if (_canDialog.boolValue)
            EditorGUILayout.PropertyField(_dialogNodeGraph);
    }
}