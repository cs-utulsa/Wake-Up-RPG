using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get;  }
    public SaveSystem curSave;
    [SerializeField] private TextMeshProUGUI curDay;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        load();
    }
 

    public void save()
    {
        if (/*win == */true)
        {
            curSave.dayOfWeek++;
        }
        curSave.lastPlayed = DateTime.Now.DayOfYear; 
        //small chance of bug if someone doesn't play for a year exactly will not be able to play
        //start should check if it is a different day not that it is the next day
        //check just !lastPlayed
        PlayerPrefs.SetString("save", SaveHelper.serialize<SaveSystem>(curSave));
    }

    public void load()
    {
        if (PlayerPrefs.HasKey("save")) //checks if we have a save
        {
            curSave = SaveHelper.deserialize<SaveSystem>(PlayerPrefs.GetString("save"));
        }
        else
        {
            curSave = new SaveSystem();
            save();
            //new save
        }
    }
}
