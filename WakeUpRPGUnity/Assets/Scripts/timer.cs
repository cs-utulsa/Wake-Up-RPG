using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//esists for when after the player hits the play button
public class customTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public int lengthTime = 15;  //convert to an easily adjustable value for play testing

    private float targetTime = 15 * 60.0f; //minutes

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }

    void timerEnded()
    {

    }
}
