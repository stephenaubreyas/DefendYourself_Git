using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Editor : EditorWindow
{
    [MenuItem("DefendYourself/GameWindow")]
    public static void CreateWindow()
    {
        GetWindow<Editor>("Defend Yourself");
    }

    private void OnGUI()
    {
        if(GUILayout.Button("GetPosition"))
        {
           Debug.Log("Player Position" +  PlayerDefender.Instance.transform.position);
        }
    }
}
