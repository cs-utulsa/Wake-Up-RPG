/**
 * Created By: Aidan Pohl
 * Created: 02/19/2022
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: 03/07/2022
 * 
 * Description: Laser Beam Detection
 *
 * 
 * */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetection : MonoBehaviour
{   
    /*** VARIABLES ***/
    [Header("Set In Inspector")]
    public Material unlitMat;
    public Material litMat;
    public Material shadowMat;
    public bool selectable;
    [Header("Set Dynamically")]
    public bool laserLit = false;
    public bool wasLit = false;
    private MeshRenderer mesh;
    private GameObject currentCollision;
    // Start is called before the first frame update
    void Start()
    { 
        mesh = gameObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
        mesh.material = unlitMat;
    }//end Start()

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Laser" && currentCollision == null){
            laserLit = true;
            wasLit = true;
            if(selectable){
            gameObject.GetComponent<PlayerControllable>().interactable = true;
            }//end if(selectable)
            UpdateMat();
            currentCollision = other.gameObject;
        }//end if(other.gameObject.tag == "Laser" && currentCollision == null)
    }//end OnTriggerEnter

    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Laser" && other.gameObject == currentCollision){
            Debug.Log("Oy!");
            if(selectable){
            gameObject.GetComponent<PlayerControllable>().interactable = false;
            }//end if(selectable)
            laserLit = false;
            currentCollision = null;
            UpdateMat();
        }//end if(other.gameObject.tag == "Laser" && other.gameObject == currentCollision)
    }//end OnTriggerExit

    private void UpdateMat(){
        if (laserLit){
            mesh.material = litMat;
        }//end ifelse
    }//end UpdateMat()
}
