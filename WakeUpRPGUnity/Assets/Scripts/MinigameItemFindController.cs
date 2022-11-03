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
    GameManager GM = GameManager.GM;
    //public string narrScene;
    public GameObject[] rooms;
    public GameObject[] items;
    public bool[] itemCollected;
    public string[] itemDescriptions;
    public GameObject ExitButton;

    public GameObject minigameCanvas;
    public GameObject endDayCanvas;

    public GameObject winText;
    public GameObject loseText;

    // Start is called before the first frame update
    void Awake()
    {
        mifc = this;
    }

    // Update is called once per frame
    void Update()
    {//Debug.Log(Input.mousePosition.ToString());
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
        itemCollected[itemNum] = true;
        if (InventoryCheck()){ExitButton.GetComponent<Button>().interactable = true;}
    } 


    public void EndMinigame(){
        if(InventoryCheck()){
            GM.minigameResult = true;
            
        }else{ GM.minigameResult = false;}

        minigameCanvas.SetActive(false);
        endDayCanvas.SetActive(false);
        if(GM.minigameResult){
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
