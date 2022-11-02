/**
 * Created By: Aidan Pohl
 * Created: 03/06/2022
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: 03/07/2022
 * 
 * Description: Update global text in end screen canvas
 * */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Reference to user interface

public class EndCanvas : MonoBehaviour
{       /***VARIABLES***/
    GameManager gm; //reference to the game manager

    [Header("Canvas Settings")]
    public Text timer;
    public Text highscore;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM;
        TimeSpan winTime = GameManager.timer.Elapsed.Duration();
        timer.text ="Game Won in "+ winTime.ToString(@"hh\:mm\:ss");

    }//end Start()

    public void StartScreen(){
        gm.StartScreen();
    }//end StartScreen()

    public void ExitGame(){
        gm.ExitGame();
    }//end ExitGame()
}
