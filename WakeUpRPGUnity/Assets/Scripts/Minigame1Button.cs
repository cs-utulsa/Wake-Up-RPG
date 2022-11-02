/***
*
*Created By: Aidan Pohl
*Created: Nov 1, 2022
*
*Modified By: N/A
*Modified: Nov 2, 2022
*
*Description: Script for Item Buttons to make collection easier
***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Minigame1Button : MonoBehaviour
{
    // Start is called before the first frame update
    
    MinigameItemFindController MIFC = MinigameItemFindController.MIFC;
    public int itemNum;
    
    void Start(){
        MIFC = MinigameItemFindController.MIFC;
    }
    public void ItemGet(){
        MIFC.GetItem(itemNum);
        this.gameObject.SetActive(false);
    }
}
