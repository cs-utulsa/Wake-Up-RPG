using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject maze;
    public bool inGame = true;
    public void EndGame(bool victory){
        if (inGame){
            inGame= false;
        FreezeAll();
        if(victory){
            //Victory Screen
        } else {
            //Fail Screen
        }
}
    }

    void FreezeAll(){
        GameObject.Find("Player").GetComponent<PlayerMovement>().SetMoveable(false);
        foreach(Transform item in maze.transform){
            foreach(Transform enemy in item){
            if(enemy.gameObject.tag=="Enemy"){
                enemy.gameObject.GetComponent<EnemyMovement>().SetTarget(null);
            }
        }}
    }
}
