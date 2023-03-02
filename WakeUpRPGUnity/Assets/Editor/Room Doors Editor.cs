using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(RoomDoors))]

public class RoomDoorsEditor : Editor
{
    protected virtual void OnSceneGUI()
    {
        RoomDoors doors = (RoomDoors)target;

        Handles.BeginGUI();
        Vector3 rectMin = Camera.current.WorldToScreenPoint(doors.transform.position);
        //creates rectangles for the door buttons
        float sceneHeight = SceneView.currentDrawingSceneView.position.height;
        var rectN = new Rect(rectMin.x - 25,        sceneHeight - rectMin.y - 125,  50, 20);
        var rectE = new Rect(rectMin.x - 25 +100,   sceneHeight - rectMin.y -25,       50, 20);
        var rectS = new Rect(rectMin.x - 25,        sceneHeight - rectMin.y + 65,  50, 20);
        var rectW = new Rect(rectMin.x - 25 - 100,  sceneHeight - rectMin.y - 25 ,       50, 20);
        
        GUILayout.BeginArea(rectN);//button for north door toggle
        if (GUILayout.Button("North"))
        {
            doors.ToggleDoor('N');
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(rectE);//button for east door toggle
        if (GUILayout.Button("East"))
        {
            doors.ToggleDoor('E');
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(rectS);//button for South door toggle
        if (GUILayout.Button("South"))
        {
            doors.ToggleDoor('E');
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(rectW);//button for north door toggle
        if (GUILayout.Button("West"))
        {
            doors.ToggleDoor('W');
        }
        GUILayout.EndArea();

        Handles.EndGUI();

        //if (Handles.Button(position, Quaternion.identity, size, pickSize, Handles.RectangleHandleCap))
           // Debug.Log("The button was pressed!");
    }

}
