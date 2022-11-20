/**
 * Created By: Aidan Pohl
 * Created: 03/06/2022
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: 03/07/2022
 * 
 * Description: Update global text in start canvas
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Reference to user interface

public class StartCanvas : MonoBehaviour
{   
/***VARIABLES***/
    GameManager gm; //reference to the game manager

    [Header("Canvas Settings")]
    public Text titleTextBox;
    ///public Text creditsTextBox;
    //public Text copyrightTextBox;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM;
        titleTextBox.text = gm.gameTitle;
        //creditsTextBox.text = gm.gameCredits;
        //copyrightTextBox.text = gm.copywriteDate;
    }//end Start()

    public void StartGame(){
        gm.StartGame();
    }//end StartGame()

    public void ExitGame(){
        gm.ExitGame();
    }//end ExitGame()
}
