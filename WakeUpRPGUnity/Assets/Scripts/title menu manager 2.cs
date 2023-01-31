//github fun

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuManager : MonoBehaviour
{

    //public GameObject[] menus;
    //private GameObject currentMenu = menus[0]; //starts on title
    //public GameObject destinationMenu; 

    // Start is called before the first frame update
    void Start()
    {
        //set all menus except title to disable
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    void MenuSwitch
    {
        //disable current menu
        //enable desitination menu
    }
    */

    //does not seem to work
    void popUpWindow(GameObject obj)
    {
        obj.SetActive(true);
    }
    void closeWindow(GameObject obj)
    {
        obj.SetActive(false);
    }

}