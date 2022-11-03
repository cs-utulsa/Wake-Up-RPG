/**
 * Created By: Aidan Pohl
 * Created: 10/05/2022
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: 10/05/2022
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
    public Text NarrationBox;

    [Header("GameScene")]
    public string MinigameSceneName;

    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GM;
     }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText (int type){
        UnityEngine.Debug.Log("Ping!");
        if (type == 0 && sIndexes[type] >= StartingText.Length){
            SceneManager.LoadScene(MinigameSceneName);
        } else if ((type == 1 && sIndexes[type] >= SuccessText.Length) || (type == 2 && sIndexes[type] >= FailText.Length) || (type == 3 && sIndexes[type] >= TimeOutText.Length)){
            GameManager.gameState = GameManager.gameStates.GameWin;
        }
        string narration = NarrationBox.text;
        narration = //narration+"\n"+
            StartingText[sIndexes[type]];
        NarrationBox.text = narration;
        sIndexes[type]++;

    }
}
