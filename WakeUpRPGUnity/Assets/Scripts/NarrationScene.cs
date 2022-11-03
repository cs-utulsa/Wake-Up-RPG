/**
 * Created By: Aidan Pohl
 * Created: 10/05/2022
 * 
 * Last Edited By: Brennan Gillespie
 * Last Edited: 11/02/2022
 * 
 * Description: Game Module
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //Reference to user interface

public class NarrationScene : MonoBehaviour
{
    [Header("Narration")]
    public string[] StartingText;
    public string[] SuccessText;
    public string[] FailText;
    public string[] TimeOutText;

    int [] sIndexes = {0,0,0,0};

    public Text narrationBox;

    public GameObject arcade;
    public GameObject library;
    public GameObject books;
    public GameObject window;
    public GameObject dryWall;
    public GameObject calander;

    [Header("GameScene")]
    public string MinigameSceneName;

    GameManager gm;
    // Start is called before the first frame update

    void Start()
    {
        gm = GameManager.GM;

        
        books.SetActive(false);
        window.SetActive(false);
        dryWall.SetActive(false);
        calander.SetActive(false);
        library.SetActive(false);
        arcade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //cheap fix

    public void UpdateText (int type){
        UnityEngine.Debug.Log("Ping!");
        if (type == 0 && sIndexes[type] >= StartingText.Length){
            SceneManager.LoadScene(MinigameSceneName);
        } else if ((type == 1 && sIndexes[type] >= SuccessText.Length) || (type == 2 && sIndexes[type] >= FailText.Length) || (type == 3 && sIndexes[type] >= TimeOutText.Length)){
            GameManager.gameState = GameManager.gameStates.GameWin;
        }

        if(sIndexes[0] == 2)
        {
            arcade.SetActive(true);
        }
        else if (sIndexes[0] == 4)
        {
            arcade.SetActive(false);
            library.SetActive(true);
        }
        else if (sIndexes[0] == 6)
        {
            library.SetActive(false);
        }
        else if((sIndexes[0] == 10 || sIndexes[0] == 25))
        {
            books.SetActive(true); //to bokkss (from birds)
        } 
        else if (sIndexes[0] == 14 )
        {
            books.SetActive(false);
            window.SetActive(true); //to window
        }
        else if (sIndexes[0] == 20)
        {
            window.SetActive(false);
            dryWall.SetActive(true); //to drywall
        }
        else if (sIndexes[0] == 22)
        {
            dryWall.SetActive(false); //back to birds
        }
        /*else if (type == __)
        {
            //back to books
        }*/
        else if (sIndexes[0] == 31)
        {
            books.SetActive(false);//calander
            calander.SetActive(true);
        }
        //go to mini game
        if(sIndexes[type] < StartingText.Length){
        narrationBox.text = StartingText[sIndexes[type]];
        sIndexes[type]++;
    }

    }
}
