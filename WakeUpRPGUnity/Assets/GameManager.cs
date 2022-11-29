/**
 * Created By: Aidan Pohl
 * Created: 02/23/2022
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: 10/05/2022
 * 
 * Description: Game Managaer
 * */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    /***VARIABLES***/
    #region GameManager Singleton
    static private GameManager gm; // reference to Game Manager
    static public GameManager GM  { get {   return gm;  }   }//public access to Game manager

    void CheckGameManagerIsInScene(){
        if (gm == null){
            gm = this;
        }else{
            Destroy(this.gameObject);
        }//end if else
        DontDestroyOnLoad(this); //Do not destroy the game manager when new scene is loaded
    }//end CheckGameManagerIsInScene()

    #endregion

    //added by breannan
    public alarm alarm;

[Header("General Settings")]
public string gameTitle = "Wake Up RPG";
public string gameCredits = "Made by: THE GANG";
public string copywriteDate = "Copyright " + thisDate;

[Header("Game Settings")]
[Header("Scene Settings")]
[Tooltip("Name of start scene")]
public string startString;

[Tooltip("Name of end Scene")]
public string endScene;

[Tooltip("Count and name of each scene")]
public string[] gameLevels;
private int gameLevelsCount;
[SerializeField]private bool nextLevel = false;//test for next level

public static int currentScene = 0; //the current level id

[HideInInspector] public enum gameStates {Idle,Narration,Playing,StartScreen,LevelWin,LevelLose,LevelTimeOut,GameWin};//enum of game states
[HideInInspector] public static gameStates gameState = gameStates.StartScreen; //curent gamestate
[HideInInspector] public static Stopwatch timer = new Stopwatch();
private static string thisDate = System.DateTime.Now.ToString("yyyy"); //todays date as string
public bool minigameResult = false;


/***Methods***/
    void Awake(){
    CheckGameManagerIsInScene();
    currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    alarm = new alarm();
    }//end Awake()

void Update(){
    //UnityEngine.Debug.Log(gameState);
    if(Input.GetKey("escape")){ExitGame();} //esc key to exit game

    if(nextLevel){NextLevel();} // move to next level 
    if (gameState == gameStates.LevelWin){
            //Invoke("NextLevel", 5);
            //gameState = gameStates.Idle;
    }//end if else()
}//end Update

public void StartGame(){
    if (/*alarm.inTimeFrame() ==*/ true)
    { //Modified startgame by Brennan Gillespie
        gameLevelsCount = 0;
        gameState = gameStates.Playing;//playing game state
        timer = Stopwatch.StartNew();
        SceneManager.LoadScene(gameLevels[gameLevelsCount]); //load first level
    }
}//end StartGame();

public void ExitGame(){
    Application.Quit();
    UnityEngine.Debug.Log("Exited Game");
}//end ExitGame

public void GameEnd(){
    gameState = gameStates.GameWin;//game end state
    timer.Stop();
    SceneManager.LoadScene(endScene);
    UnityEngine.Debug.Log("Game End Scene");
}//end GameEnd()

public void NextLevel(){
    UnityEngine.Debug.Log("level complete");
    nextLevel = false;
    if(gameLevelsCount < gameLevels.Length-1){
        gameLevelsCount++;
        SceneManager.LoadScene(gameLevels[gameLevelsCount]);
        gameState = gameStates.Playing;
        timer.Start();
    }else{
        GameEnd();
    }//end if else
}//End NextLevel()

public void StartScreen(){
    SceneManager.LoadScene(startString);
    gameState=gameStates.StartScreen;
}//end StartScreen()

}
