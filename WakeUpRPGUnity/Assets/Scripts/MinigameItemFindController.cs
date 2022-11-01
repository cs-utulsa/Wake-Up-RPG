/***
* Created by: Aidan Pohl
* Created: Oct 29, 2022
* Modified: Oct 30, 2022
* Purpose Manages the minigam rooms and items
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MinigameItemFindController : MonoBehaviour
{   
    GameManager GM = GameManager.GM;
    public string narrScene;
    public GameObject[] rooms;
    public GameObject[] items;
    public bool[] itemCollected;
    public string[] itemDescriptions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {Debug.Log(Input.mousePosition.ToString());
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
        this.SetActive(false);
    } 
}
