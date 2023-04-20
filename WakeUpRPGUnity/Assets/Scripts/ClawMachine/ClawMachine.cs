using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachine : MonoBehaviour {

    public GameObject clawOpen;
    public GameObject clawClose;
    public GameObject clawNow;
    public static float speed;
    public static bool moverIzq;
    public static bool stopMovSides = false;
    public static bool insideMoveDown = false;
    public static bool insideMoveUp = false;
    public Vector3 posStart;

    public static bool clawClosed = false;

    //public GameObject clawDown;
    // Start is called before the first frame update
    void Start() {

        speed = 1f;
        
        clawClose.SetActive(false);
        clawOpen.SetActive(true);
        clawNow = clawOpen;
        moverIzq = true;

    }

    // Update is called once per frame
    void Update() {
    
        //Ponerlo en el botón
        if(clawClosed) {
             clawClose.SetActive(true);
             clawOpen.SetActive(false);
             clawNow = clawClose;
        }

        
        /*if(Input.GetMouseButtonDown(0)) {
            
             //insideMoveDown = true;
        }*/

        if(!stopMovSides) {
            moveClawSides();
        }

        if(insideMoveDown) {
             moveClawDown();
        }

        if(insideMoveUp) {
             moveClawUp();
        }
        
    
    }

    //Saber donde anda
    public Vector3 posNow {

        get {
            return clawNow.transform.position;
        } set {
            clawNow.transform.position = value;

        }
    }

    //Saber donde anda
    public Vector3 posClose {

        get {
            return clawClose.transform.position;
        } set {
            clawClose.transform.position = value;

        }
    }

    public void moveClawDown() {

        stopMovSides = true;

        Vector3 tempPos = posNow;

        guardarValores(tempPos);
        
        if(tempPos.y < -2.49) {
            //posStart = tempPos;
            insideMoveDown = false;
        }
    
        tempPos.y -= speed * Time.deltaTime;
        posNow = tempPos;

    }

    public void guardarValores(Vector3 tempoPos) {

        posStart.x = tempoPos.x + 0.55f;
        posStart.y = (float)-2.55;

    }

    public void moveClawUp() {

        
        Vector3 tempPos = posNow;

        
        /*if(tempPos.y > 2.26) {
            insideMoveUp = false;
        }*/
    
        tempPos.y += speed * Time.deltaTime;
        posNow = tempPos;

    }

    void moveClawSides() {

        Vector3 tempPos = posNow;

        if(posNow.x < -1.424) {
            moverIzq = false;
        }
        if(posNow.x > 1.076) {
            moverIzq = true;
        }

        if(!moverIzq) {
            tempPos.x += speed * Time.deltaTime;
            posNow = tempPos;
        }

        if(moverIzq) {
            tempPos.x -= speed * Time.deltaTime;
            posNow = tempPos;
        }

        Vector3 tempPos2 = posNow;

        if(posNow.x < -0.7) {
            moverIzq = false;
        }
        if(posNow.x > 1.98) {
            moverIzq = true;
        }

        if(!moverIzq) {
            tempPos2.x += speed * Time.deltaTime;
            posNow = tempPos2;
        }

        if(moverIzq) {
            tempPos2.x -= speed * Time.deltaTime;
            posNow = tempPos2;
        }

    }

   
}
