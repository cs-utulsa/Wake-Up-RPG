/**
 * Created By: Aidan Pohl
 * Created: 02/20/2022
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: 03/07/2022
 * 
 * Description: Player Controller script
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllable : MonoBehaviour
{   public bool hoverOver;
    private GameObject gameController;
    public bool interactable;
    private GameObject indicator;
    public GameObject indicatorPrefab;
    public GameObject movingObject  ;
    public bool rotatable;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("_GameManager");
        indicator = Instantiate(indicatorPrefab, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        indicator.SetActive(false);
    }//end Start()

    void OnMouseDown(){
        if (interactable)
        transform.Rotate(90, 0, 0);
    }//end OnMouseDown()

    public void SetHalo(bool halo){
        if(halo){
            indicator.SetActive(true);
        } else{
            indicator.SetActive(false);
        }
    }//end SetHalo(bool Halo)

    /**void Update(){
        if(hoverOver && interactable){
            SetHalo(true);
        }else if (gameController.GetComponent<PlayerControls>().selectedObject != gameObject){
            SetHalo(false);
        }//end if else()
    }//end Update()
    **/

}
