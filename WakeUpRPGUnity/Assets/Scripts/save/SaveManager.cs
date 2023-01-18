using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get;  }
    public SaveSystem curSave;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        load();
    }

    public void save()
    {
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
