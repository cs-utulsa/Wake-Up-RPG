
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class RoomDoors : MonoBehaviour
{
    [Header("Set in Script, Shown just for Debugging")]
    [SerializeField]private GameObject doorN;
    [SerializeField]private GameObject doorE;
    [SerializeField]private GameObject doorS;
    [SerializeField]private GameObject doorW;
    [SerializeField]private bool[] openDoors = new bool[4]{false,false,false,false}; //{N,E,S,W}
    [SerializeField]private bool mapped = false;
    [SerializeField]private int[] mazeLoc;
    private int distToExit;

    // Start is called before the first frame update
    void Start()
    {   
        //openDoors = new bool[4]{false,false,false,false};//All doors are closed by default
    }//end Start

    public void SetDoors(string doors){ //uses a string to set states of all doors
        if(doors.Contains("N")||doors.Contains("U"))
            openDoors[0] = true;
            else
            openDoors[0] = false;
        if(doors.Contains("E")||doors.Contains("R"))
            openDoors[1] = true;
            else
            openDoors[1] = false;
        if(doors.Contains("S")||doors.Contains("D"))
            openDoors[2] = true;
            else
            openDoors[2] = false;
        if(doors.Contains("W")||doors.Contains("L"))
            openDoors[3] = true;
            else
            openDoors[3] = false;
        UpdateDoors();
    }

    private void UpdateDoors(){ //updates the doors
            doorN.SetActive(!openDoors[0]);
            doorE.SetActive(!openDoors[1]);
            doorS.SetActive(!openDoors[2]);
            doorW.SetActive(!openDoors[3]);
    }//end UpdateDoors()

    public void OpenDoor(char direction){//opens a single door
        switch(direction){
            case('N'):case('U'):
                openDoors[0] = true;
                break;
            case('E'): case('R'):
                openDoors[1] = true;
                break;
            case('S'): case('D'):
                openDoors[2] = true;
                break;
            case('W'): case('L'):
                openDoors[3] = true;
                break;
        }
        UpdateDoors();
    }//end OpenDoor

    public void OpenBackDoor(char direction){//opens door opposed of direction, used to open door adjacent to connecting door in adjacent room.
        switch(direction){
            case('N'):case('U'):
                openDoors[2] = true;
                break;
            case('E'): case('R'):
                openDoors[3] = true;
                break;
            case('S'): case('D'):
                openDoors[0] = true;
                break;
            case('W'): case('L'):
                openDoors[1] = true;
                break;
        }
        UpdateDoors();
    }//end OpenBackDoor

    public void CloseDoor(char direction){ //closes a single door
        switch(direction){
            case('N'):case('U'):
                openDoors[0] = false;
                break;
            case('E'): case('R'):
                openDoors[1] = false;
                break;
            case('S'): case('D'):
                openDoors[2] = false;
                break;
            case('W'): case('L'):
                openDoors[3] = false;
                break;
        }
        UpdateDoors();
    }//end CloseDoor

    public void markMapped(bool visited){
         mapped = visited;
    }//end markMapped

    public bool getMapped(){
        return mapped;
    }//end getMapped

    public int numDoors(){//Returns number of open doors in room
        int num = 0;
        foreach (bool door in openDoors){
            if (door == true){
                   num++;
            }
        }
    return num;
    }//end NumDoors

    public int[] getMazeLoc (){
        return mazeLoc;
    }

    public void setMazeLoc(int x, int y){
        mazeLoc = new int[]{x,y};
    } 

    public char getRelDirect(int[] otherLoc){//gets direction from otherLoc to mazeLoc
        if (otherLoc[1] > mazeLoc[1]){ return 'N';
        }else if( otherLoc[0]< mazeLoc[0]){return 'E';
        } else if(otherLoc[1]< mazeLoc[1]){return 'S';
        }else if (otherLoc[0]> mazeLoc[0]){return 'W';
        } else{ return '0';}//end elif
    }//end getRelDirect

    public int getDistToExit(int exitX,int exitY){
        return (System.Math.Abs(mazeLoc[0]-exitX)+System.Math.Abs(mazeLoc[1]-exitY));
    }

    public void ToggleDoor(char direction)
    {
        switch (direction)
        {
            case ('N'):
            case ('U'):
                openDoors[0] = !openDoors[0];
                break;
            case ('E'):
            case ('R'):
                openDoors[1] = !openDoors[1];
                break;
            case ('S'):
            case ('D'):
                openDoors[2] = !openDoors[2];
                break;
            case ('W'):
            case ('L'):
                openDoors[3] = !openDoors[3];
                break;
        }
        UpdateDoors();
    }
    }
