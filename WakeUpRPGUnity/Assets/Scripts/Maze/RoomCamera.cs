using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : MonoBehaviour
{   
    [SerializeField]private GameObject walls;
    [SerializeField]private GameObject corners;
    [SerializeField]private GameObject floor;
    Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other){
        mainCam = Camera.main;
       // Debug.Log("Ping?");
        if(other.gameObject.tag == "Player"){
            mainCam.GetComponent<CameraFollower>().SetTarget(this.transform);
        }
        if(other.gameObject.tag == "Render"){
            Unhide();
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        //Debug.Log("Ping exit");
        if(other.gameObject.tag == "Render"){
           //Hide();
        }
    }

    public void Hide(){
        walls.SetActive(false);
        corners.SetActive(false);
        floor.SetActive(false);
    }

    public void Unhide(){
        walls.SetActive(true);
        corners.SetActive(true);
        floor.SetActive(true);
    }
}
