using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SaveJson : MonoBehaviour
{
    public Memory mem; //Leaving this public is risky...
    float timer = 0f;

    #region SaveData Singleton
    static private SaveJson data;
    static public SaveJson DATA { get { return data; } }

    void CheckDataInScene()
    {

        if (data == null)
        {
            data = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    private void Awake()
    {
        CheckDataInScene();

        string filePath = Application.persistentDataPath + "/SaveData.json";
        string data = System.IO.File.ReadAllText(filePath);
        if (data == "" || data == null)
        {
            CreateNewData();
        }
        else
        {
            LoadFromJson();
        }

    }
    private void Update()
    {
        //Auto saving system
        timer += Time.deltaTime;
        if (timer > 30f)
        {
            timer = 0f;
            SaveToJson();
        }
    }

    #region Data Saving and Loading
    private void CreateNewData()
    {
        mem = new Memory();
        SaveToJson();
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/SaveData.json";
        string data = System.IO.File.ReadAllText(filePath);

        mem = JsonUtility.FromJson<Memory>(data);

    }

    public int LoadLevel()
    {
        string filePath = Application.persistentDataPath + "/SaveData.json";
        string data = System.IO.File.ReadAllText(filePath);
        mem = JsonUtility.FromJson<Memory>(data);
        Debug.Log(mem.level);
        return mem.level;
    }

    public void SaveToJson()
    {
        string saveData = JsonUtility.ToJson(mem);
        string filePath = Application.persistentDataPath + "/SaveData.json"; //For my local machine: C:/Users/cpWhe/AppData/LocalLow/DefaultCompany/Jam Maker Unity/SaveData.json
        System.IO.File.WriteAllText(filePath, saveData);
        Debug.Log("Saved data");
    }

    public void ClearData()
    {
        CreateNewData();
    }
    #endregion
}

[System.Serializable]
public class Memory
{
    public float volume;
    public int level;

    public Memory()
    {
        //Create with default values
        volume = 1f;
        level = 0;
    }
}
