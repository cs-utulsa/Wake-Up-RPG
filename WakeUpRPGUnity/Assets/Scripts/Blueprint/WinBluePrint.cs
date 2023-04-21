using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBluePrint : MonoBehaviour
{
    private int totPoints;
    private int curPoints;
    public GameObject parts;

    // Start is called before the first frame update
    void Start()
    {
        totPoints = parts.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(curPoints >= totPoints)
        {
            //Win
            Debug.Log("Win");
            SceneManager.LoadScene("SelectDayToStart");
        }
        
    }

    public void addPoints()
    {
        curPoints++;
    }
}
