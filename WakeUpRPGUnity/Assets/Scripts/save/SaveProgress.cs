using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour
{
    public int level;

    public void save()
    {
        PlayerPrefs.SetInt("level", level);
        Debug.Log("Current Level");
    }

    public void createSave()
    {
        level = 0;
    }

    public void nextLevel()
    {
        level++;
        save();
    }
}
