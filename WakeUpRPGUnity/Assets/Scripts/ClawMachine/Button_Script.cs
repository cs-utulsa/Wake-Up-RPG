using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Script : MonoBehaviour {

    public GameObject buttonDown;
    public GameObject buttonUp;


    // Start is called before the first frame update
    void Start() {
       
    }

    // Update is called once per frame
    void Update() {

        if(Input.touchCount > 0) {

            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began) { //&& gameObject.GetComponent<Collider2D>() == Physics2D.OverlapPoint(touch.position)) {
            
                buttonUp.SetActive(false);
                buttonDown.SetActive(true);

                Debug.Log("Ha tocado el botón");

                ClawMachine.insideMoveDown = true;

            }
           
        }
        
    }

    /*void OnTriggerEnter(Collider collider) {
    
        buttonUp.SetActive(false);
        buttonDown.SetActive(true);

        ClawMachine.insideMoveDown = true;
    
    }*/
}

