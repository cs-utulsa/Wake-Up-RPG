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

    [Header("Backgrounds")]
    /*
    public GameObject arcade;
    public GameObject library;
    public GameObject books;
    public GameObject window;
    public GameObject dryWall;
    public GameObject calander;
    */

    public GameObject[] backgrounds;
    public int[] switchTime_time;
    public int[] switchTime_back;
    private int switchTime_pos = 1;

    [Header("GameScene")]
    public string MinigameSceneName;

    GameManager gm;
    // Start is called before the first frame update

    void Start()
    {
        gm = GameManager.GM;

        //switchTime = new switchTime[backgrounds.GetLength(), 4 ];

        /*
        books.SetActive(false);
        window.SetActive(false);
        dryWall.SetActive(false);
        calander.SetActive(false);
        library.SetActive(false);
        arcade.SetActive(false);
        */
        backgrounds[0].SetActive(true);
        for (int i = 1; i< backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(false);
        }

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


        try
        {
            if (switchTime_time[switchTime_pos] == sIndexes[0])
            {
                backgrounds[switchTime_back[switchTime_pos - 1]].SetActive(false);
                backgrounds[switchTime_back[switchTime_pos]].SetActive(true);
                switchTime_pos += 1;
            }
        }
        catch { }


        /*
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
        } //reapply * /
        else if (sIndexes[0] == 31)
        {
            books.SetActive(false);//calander
            calander.SetActive(true);
        }
        */
        //go to mini game
        if(sIndexes[type] < StartingText.Length){
        narrationBox.text = StartingText[sIndexes[type]];
        sIndexes[type]++;
    }

    }
}
