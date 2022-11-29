using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//determines the window in which the player is allowed to start the play session
public class alarm : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI curTimeText;
    [SerializeField] private TMP_InputField hoursIn, minutesIn;
    [SerializeField] private TMP_Dropdown dropDown;

    private bool isAlarmSet = false;
    private DateTime alarmTime = DateTime.Today;
    private DateTime windowTime = DateTime.Today;

    private int windowSize = 15;

    void Awake() { }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        int hours = DateTime.Now.Hour;
        int minutes = DateTime.Now.Minute;

        bool isAM = hours < 12;

        curTimeText.text = $"{hours % 12:D2}:{minutes:D2} {(isAM ? "AM" : "PM")}";//insert line to display current time in UI

        if (isAlarmSet)
        {
            //Debug.Log("alarm frame");
            if (inTimeFrame() == true)
            {
                //allow Play
                Debug.Log("can Play");
                //once in in game manager start a 15 minute timer
            }
        }
    
    }

    void setWindow(int h, int m, int w)
    {
        int tempM = m + w;
        if(tempM >= 60)
        {
            tempM -= 60;
            h += 1;
        }
        TimeSpan ts = TimeSpan.Parse($"{h}:{m}");
        windowTime += ts;
        //while (DateTime.Now >= windowTime)
        {
          //  windowTime = windowTime.AddDays(1);
        }
        Debug.Log("window set");
    }

    public void setAlarm() //add code to restrict to the AM probably between 5 and 10 AM
    {
        int hours;
        int minutes;
        minutes = int.Parse(minutesIn.text); //check for invalid minute amounts
        if (dropDown.value == 0)
        {
            hours = int.Parse(hoursIn.text); //need to create a try catch exception for invalid inputs
        }
        else //catches PM
        {
            hours = int.Parse(hoursIn.text) + 12;
        }
        
        TimeSpan ts = TimeSpan.Parse($"{hours}:{minutes}");
        alarmTime += ts;
        Debug.Log("set1");
        //while (DateTime.Now >= alarmTime)
        {
        //    alarmTime = alarmTime.AddDays(1);
        }

        setWindow(hours, minutes, windowSize);

        isAlarmSet = true;
        Debug.Log("set2");
    }

    public bool inTimeFrame() //returns wether you are in the correct frame of time for the 
    {
        if (DateTime.Now >= alarmTime && DateTime.Now <= windowTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
