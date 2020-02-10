using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Board))]
public class BoardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Board control = (Board)target;

        if (GUILayout.Button("SetupBoard"))
        {
            //control.SetupBoard(); 
            Debug.Log("Please don't try this! Already Instantiated. and this is not your business!");
        }
    }
}
