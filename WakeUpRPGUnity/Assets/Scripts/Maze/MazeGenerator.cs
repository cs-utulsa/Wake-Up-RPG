/**
 * 
 * Created by: Aidan Pohl
 * Created: Sometime in 2020
 * 
 * Last edited by: Adian Pohl
 * Last edited: March 1, 2023
 * 
 * Description: Handles the creation and optional path generation of a maze of predetwrmined width and height
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class MazeGenerator : MonoBehaviour {

    public int mazeWidth , mazeHeight, startX, startY,exitX,exitY;
    //public static string mazeSeed;
    public bool generateRooms = false;
    public bool generatePaths = false;
    public bool hideRooms = true;
    public GameObject roomPrefab;
    public GameObject goalPrefab;
    public GameObject playerGO;
    [SerializeField] private GameObject[,] maze;
    System.Random rand = new System.Random();


    void Start() {
        if (generateRooms)
        {
            GenerateRooms();
        }
        if (generatePaths) { 
             GeneratePaths(); }
        if (hideRooms)
        {
            foreach (GameObject room in maze)
            {
                room.GetComponent<RoomCamera>().Hide(); //hides all rooms
            }
        }
        SetStartAndExit();
        
   }//end Start
    public void GenerateRooms()//This part generates a grid of enclosed rooms of size mazeWidth x mazeHeight
    {
        if (maze != null)
        {
            foreach (GameObject room in maze)//deletes preexisting rooms
            {
                DestroyImmediate(room);
            }
        }

        maze = new GameObject[mazeWidth, mazeHeight];
        for (int i = 0; i < mazeHeight; i++)
        {
            for (int j = 0; j < mazeWidth; j++)
            {
                maze[j, i] = Instantiate(roomPrefab, new Vector3(j * 10f - (mazeWidth / 2 * 10), i * -10f - (mazeHeight / 2 * 10), 0), Quaternion.identity, transform);// Makes a new Room at the location in the grid.
                maze[j, i].GetComponent<RoomDoors>().setMazeLoc(j, i); //Records the relative location in the Room.
                maze[j, i].name = "Room (" + i + ", " + j + ")"; //names the room so its *slightly* less confusing
            }// end for loop
        }//end for loop


    }
   public void GeneratePaths(){ //The code that carves out the maze. Uses a depth-first tree to generate the maze.
       foreach(GameObject room in maze)
        {
            room.GetComponent<RoomDoors>().SetDoors("");
        }
       int visitedCells = 1;
       int totalCells = mazeWidth*mazeHeight;
       Stack<GameObject> workingCells = new Stack<GameObject>();
       workingCells.Push(maze[mazeWidth/2+1,mazeHeight/2+1]);
       while (visitedCells < totalCells){//While cells have not been visited
            GameObject curCell = workingCells.Peek(); //gets curCell from top of workingCells
            int[] mazeLoc = curCell.GetComponent<RoomDoors>().getMazeLoc(); //gets the location of curCell within maze
            int[] startLoc = {startX,startY};
            int[] exitLoc = {exitX,exitY};
            
           List<GameObject> adjacentCells = getAdjacentCellsWithWalls(mazeLoc[0],mazeLoc[1], maze); //Get adjacent cells with all walls/no doors.
           if(adjacentCells.Count != 0){ //Has adjacent cells will all walls
                GameObject randCell = adjacentCells[rand.Next(adjacentCells.Count)];//get one of the adjacent doorless cells
                char RelDirection = randCell.GetComponent<RoomDoors>().getRelDirect(mazeLoc); //get the direction from curCell to randCell.
                curCell.GetComponent<RoomDoors>().OpenDoor(RelDirection); //Opens RelDirection door in curCell
                randCell.GetComponent<RoomDoors>().OpenBackDoor(RelDirection); //Opens door that is adjacent to just opened door.
                workingCells.Push(randCell); //adds randCell to top of workingCells
                visitedCells++; //incriments visitedCells
           } else { //No adjacent cells with all walls
               workingCells.Pop(); //Pops current cell and returns to previous cell.
           }//end if - else
       }//end while
   }//end Generate


   List<GameObject> getAdjacentCellsWithWalls(int X, int Y, GameObject[,] maze){
       List<GameObject> adjacentCells = new List<GameObject>();
       List<int[]> adjCells = new List<int[]>();// List of Maze Locations of four adjacent cells
       adjCells.Add(new int[]{X-1,Y});adjCells.Add(new int[]{X+1,Y});adjCells.Add(new int[]{X,Y-1});adjCells.Add(new int[]{X,Y+1});
       foreach (int[] cell in adjCells){//loops through each cell
                if(WithinMazeBounds(cell)){//Checks if cell is within bounds of maze.
                    if(maze[cell[0],cell[1]].GetComponent<RoomDoors>().numDoors() == 0){
                        adjacentCells.Add(maze[cell[0],cell[1]]);
                    }//end if
                }//end if
       }//end foreach loop
       return adjacentCells;
   }//end getAdjacentCallsWithWalls

   private bool WithinMazeBounds(int[] loc){ //checks if given room coords are withing the bounds of the maze
       if((loc[0] >= 0) && (loc[0] < mazeWidth) && (loc[1] >= 0) && (loc[1] < mazeHeight)){
           return true;
    } else {return false;}//end if-else
   }//end WithinMazeBounds

    public void SetStartAndExit()
    {
        //Place the player in the starting room
        Vector3 startPos = maze[startX, startY].transform.position;
        playerGO.transform.position = startPos;
        Camera.main.GetComponent<CameraFollower>().target = (maze[startX, startY].transform);
        Camera.main.GetComponent<CameraFollower>().InstantFocus();

        if (goalPrefab != null)//if there is a goal prefab. create an instance and put it in the exit room
        {
            Vector3 endPos = maze[exitX, exitY].transform.position;
            Instantiate(goalPrefab, endPos, Quaternion.identity, maze[exitX, exitY].transform);
        }
    }
    public System.Random getRand(){
        return rand;
    }
}//end MazeGenerator