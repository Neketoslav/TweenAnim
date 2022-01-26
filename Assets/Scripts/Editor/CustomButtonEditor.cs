using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(CustomButton))]
public class CustomButtonEditor : ButtonEditor
{
    private SerializedProperty m_InteractableProperty;

    protected override void OnEnable()
    {
        m_InteractableProperty = serializedObject.FindProperty("m_Interactable");
    }

    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();

        var ChangeButtonType = new PropertyField(serializedObject.FindProperty(CustomButton.ChangeButtonType));
        var duration = new PropertyField(serializedObject.FindProperty(CustomButton.Duration));

        var tweenLabel = new Label("Tweens");
        var interactableLabel = new Label("Statdart Settings");


        root.Add(tweenLabel);
        root.Add(ChangeButtonType);
        root.Add(duration);

        root.Add(interactableLabel);
        root.Add(new IMGUIContainer(OnInspectorGUI));
        return root;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(m_InteractableProperty);

        EditorGUI.BeginChangeCheck();

        serializedObject.ApplyModifiedProperties();
    }
}
