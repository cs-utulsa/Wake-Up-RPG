using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class MazeGenerator : MonoBehaviour {

    public int mazeWidth , mazeHeight, startX, startY,exitX,exitY;
    //public static string mazeSeed;
    public GameObject room;
    private GameObject[,] maze;
    System.Random rand = new System.Random();

   void Start(){
       //This part generates a grid of enclosed rooms of size mazeWidth x mazeHeight
       maze = new GameObject[mazeWidth,mazeHeight];
       startX = mazeWidth/2; startY = mazeWidth/2; exitX = startX+(rand.Next(mazeWidth)-(mazeWidth/2)); exitY = startY+(rand.Next(mazeHeight)-(mazeHeight/2));
       for (int i = 0; i < mazeHeight; i++){
           for( int j = 0; j < mazeWidth; j++){
               maze[j,i] = Instantiate(room, new Vector3(j*10f-(mazeWidth/2*10),i*-10f+(mazeHeight/2*10),0), Quaternion.identity, transform);// Makes a new Room at the location in the grid.
               maze[j,i].GetComponent<RoomDoors>().setMazeLoc(j,i); //Records the relative location in the Room.
               maze[j,i].name = "Room ("+i+", "+j+")"; //names the room so its *slightly* less confusing
           }// end for loop
       }//end for loop
    Generate();
    foreach (GameObject room in maze){
        room.GetComponent<RoomCamera>().Hide(); //hides all rooms by default
        //room.GetComponent<RoomFloor>().RecolorByDistance(room.GetComponent<RoomDoors>().getDistToExit(exitX,exitY));//recolors the ground based on distance to goal
    }

        
   }//end Start

   void Generate(){ //The code that carves out the maze. Uses a depth-first tree to generate the maze.
       
       int visitedCells = 1;
       int totalCells = mazeWidth*mazeHeight;
       Stack<GameObject> workingCells = new Stack<GameObject>();
       workingCells.Push(maze[mazeWidth/2+1,mazeHeight/2+1]);
       while (visitedCells < totalCells){//While cells have not been visited
            GameObject curCell = workingCells.Peek(); //gets curCell from top of workingCells
            int[] mazeLoc = curCell.GetComponent<RoomDoors>().getMazeLoc(); //gets the location of curCell within maze
            int[] startLoc = {startX,startY};
            int[] exitLoc = {exitX,exitY};
            if(mazeLoc.SequenceEqual(startLoc) || mazeLoc.SequenceEqual(exitLoc))
            {
                curCell.GetComponent<RoomEnemies>().enableEnemies(false);
            }else{
                curCell.GetComponent<RoomEnemies>().genEnemies();
            }

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

    public System.Random getRand(){
        return rand;
    }
}//end MazeGenerator