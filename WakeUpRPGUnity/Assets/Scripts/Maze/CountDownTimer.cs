using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountDownTimer : MonoBehaviour
{   float currentTime;
    float startingTime = 120f;
    public Text timer;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {   if(currentTime > 0){
        currentTime -= 1 * Time.deltaTime;
        
        }else{
            currentTime = 0;
            GameObject.Find("GameState").GetComponent<GameOver>().EndGame(false);
        }
        timer.text = Math.Floor(currentTime).ToString();
    }

    public void UpdateTimer(float change){
        currentTime += change;
    }
}
