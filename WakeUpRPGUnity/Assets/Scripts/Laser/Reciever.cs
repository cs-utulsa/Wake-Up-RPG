/**
 * Created By: Aidan Pohl
 * Created: 02/19/2022
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: 03/07/2022
 * 
 * Description: Laser Beam Detection for Laser Reciever
 *
 * 
 * */using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciever : MonoBehaviour
{
    public bool Islit;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Laser")//Laser is hitting reciever AKA level is WIN!!!
        {
            Islit = true;
            GameManager.gameState = GameManager.gameStates.LevelWin;
            GameManager.timer.Stop();
        }//end if (other.gameObject.tag == "Laser")
    }//end OnTriggerEnter
}
