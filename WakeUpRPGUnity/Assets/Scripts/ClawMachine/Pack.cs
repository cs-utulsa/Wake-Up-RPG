using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pack : MonoBehaviour {

    public GameObject clawOpen;
    public GameObject clawClose;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnCollisionEnter(Collision collision) {

        //Debug.Log("Activado");

        if(collision.gameObject.tag == "Claw") { 

            //hace al padre el claw asi que se mueve con el
            //this.gameObject.transform.parent = collision.gameObject.transform;
           ClawMachine.insideMoveDown = false;
           ClawMachine.clawClosed = true;
           ClawMachine.insideMoveUp = true;


            //turn it off and put gravity in

        }

       

    }

}
