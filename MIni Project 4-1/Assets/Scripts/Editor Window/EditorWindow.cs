using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Editor : EditorWindow
{
    Color color;

    [MenuItem("DefendYourself/GameWindow")]
    public static void CreateWindow()
    {
        GetWindow<Editor>("Defend Yourself");
    }

    private void OnGUI()
    {
        color = EditorGUILayout.ColorField(color);

        if(GUILayout.Button("ChangeColor"))
        {
            PlayerDefender.Instance.cRenderer.material.color = color;
        }
    }
}
