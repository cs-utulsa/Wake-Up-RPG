/**
 * Created By: Aidan Pohl
 * Created: March 1, 2023
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: March 1, 2023
 * 
 * Description: Custom inspector for the Maze generator.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

    [CustomEditor(typeof(MazeGenerator))]
public class MazeGenEditor : Editor
{
    int mW = 1;
    int mH = 1;
    int sX = 0;
    int sY = 0;
    int eX = 0;
    int eY = 0;
    public override void OnInspectorGUI()
    {   
        //DrawDefaultInspector();
        MazeGenerator mazeGenScript = (MazeGenerator)target;

        //Inputs for Maze Construction
        mazeGenScript.roomPrefab = (GameObject)EditorGUILayout.ObjectField("Room Prefab", mazeGenScript.roomPrefab,typeof(Object), false);
        mazeGenScript.playerGO = (GameObject)EditorGUILayout.ObjectField("Player Game Object", mazeGenScript.playerGO, typeof(Object), true);
        mazeGenScript.goalPrefab= (GameObject)EditorGUILayout.ObjectField("Goal Prefab",mazeGenScript.goalPrefab,typeof(Object), false);
        //inputs for Maze Size
        GUILayout.Label("Maze Size",EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        mW = EditorGUILayout.IntField("Width", mazeGenScript.mazeWidth);
        mH = EditorGUILayout.IntField("Height", mazeGenScript.mazeHeight);
        GUILayout.EndHorizontal();

        //ensures mazeWidth and mazeHeight is within bounds
        if (mW < 1) { mW = 1; }
        mazeGenScript.mazeWidth = mW;
        
        if (mH <1) { mH = 1; }
        mazeGenScript.mazeHeight= mH;


        //Inputs for Start Room Location
        GUILayout.Label("Start Room",EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        sX = EditorGUILayout.IntField("X",mazeGenScript.startX);
        sY = EditorGUILayout.IntField("Y",mazeGenScript.startY);
        GUILayout.EndHorizontal();

        //Ensures Starting Room is within bounds
        if(sX < 0) { sX = 0;}
        if(sX >= mazeGenScript.mazeWidth) { sX = 1- mazeGenScript.mazeWidth; }
        mazeGenScript.startX= sX;
        
        if(sY < 0) { sY = 0;}
        if(sY>= mazeGenScript.mazeHeight) { sY= 1- mazeGenScript.mazeHeight; }
        mazeGenScript.startY= sY;

        //Inputs for End Room Location
        GUILayout.Label("End Room", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        mazeGenScript.exitX = EditorGUILayout.IntField("X", mazeGenScript.exitX);
        mazeGenScript.exitY = EditorGUILayout.IntField("Y", mazeGenScript.exitY);
        GUILayout.EndHorizontal();

        //Ensures End Room is within bounds
        if(eX< 0) { eX = 0;}
        if(eX>= mazeGenScript.mazeWidth) { eX = mazeGenScript.mazeWidth; }
        mazeGenScript.exitX= eX;

        if(eY< 0) { eY = 0;}
        if(eY>= mazeGenScript.mazeHeight) { eY= mazeGenScript.mazeHeight;}
        mazeGenScript.exitY= eY;

        if (GUILayout.Button("Generate Rooms"))
        {
            mazeGenScript.GenerateRooms();
        }

        if (GUILayout.Button("Randomly Generate Paths"))
        {
            mazeGenScript.GeneratePaths();
        }
        if(GUILayout.Button("Set Start and End"))
        {
            mazeGenScript.SetStartAndExit();
        }


    }
}
