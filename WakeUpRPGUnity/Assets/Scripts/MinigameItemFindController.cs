/***
* Created by: Aidan Pohl
* Created: Oct 29, 2022
* Modified: November 2, 2022
* Purpose Manages the minigame rooms and items
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MinigameItemFindController : MonoBehaviour
{   
    static private MinigameItemFindController mifc; // reference to Self
    static public MinigameItemFindController MIFC  { get {   return mifc;  }   }//public access
    GameManager GM;
    //public string narrScene;
    public GameObject[] rooms;
    public GameObject[] items;
    public GameObject[] listmarks;
    public bool[] itemCollected;
    public string[] itemDescriptions;
    public GameObject ExitButton;

    public GameObject minigameCanvas;
    public GameObject endDayCanvas;

    public GameObject winText;
    public GameObject loseText;

    public float gameDuration = 60.0f;
    float gameTime = 0.0f;
    public GameObject timerGO; 
    float startingHeight = 215f;
    float endheight = 513f;

    bool gameEnded = false;
    bool minigameResult;

    // Start is called before the first frame update
    void Awake()
    {
        GM = GameManager.GM;
        mifc = this;
        Vector3 sunHeight = timerGO.transform.position;
        sunHeight.y = startingHeight;
        timerGO.transform.localPosition = sunHeight;
        gameTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {//Debug.Log(Input.mousePosition.ToString());
    Debug.Log(gameTime);
    //while(!gameEnded){
        float lerpH = Mathf.Lerp(startingHeight,endheight,gameTime/gameDuration);
        Debug.Log(lerpH+"Lerp");
        Vector3 sunHeight = timerGO.transform.position;
        sunHeight.y = Mathf.Min(lerpH,endheight);
        Debug.Log(sunHeight);
        timerGO.transform.localPosition = sunHeight;
        timerGO.transform.Rotate(Vector3.forward*10*Time.deltaTime);
        gameTime += Time.deltaTime;
        if(gameTime > gameDuration){
            gameEnded = true;
            EndMinigame();
        }
   // }

    }

    public void ChangeRoom(int newroom){
        foreach (GameObject room in rooms){
            room.SetActive(false);
        }
        rooms[newroom].SetActive(true);
    }

    public void GetItem(int itemNum){
        //ItemPopup(itemNum);
        items[itemNum].transform.Find("ItemGot").gameObject.SetActive(true);
        listmarks[itemNum].SetActive(true);
        itemCollected[itemNum] = true;
        if (InventoryCheck()){ExitButton.GetComponent<Button>().interactable = true;}
    } 


    public void EndMinigame(){
        if(InventoryCheck()){
            minigameResult = true;
        }else{ minigameResult = false;}

        minigameCanvas.SetActive(false);
        endDayCanvas.SetActive(true);
        if(minigameResult){
            winText.SetActive(true);
        }else{
            loseText.SetActive(true);
        }
    }

    bool InventoryCheck(){
        bool allItems = true;
        foreach(bool gotItem in itemCollected){
            if (gotItem == false){allItems = false;
            break;}
        }
        return allItems;
    }
public void EndDay(){
    SceneManager.LoadScene("EndScene");
}
}
