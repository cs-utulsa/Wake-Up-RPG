
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float moveSpeed = 500f;
    public Rigidbody2D rb;
    bool moveable = true;

    Vector2 movement;
    private void Start()
    {
        SetMoveable(true);
    }
    // Update is called once per frame
    void Update()
    {
        /**
         * Input for computers
         * float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");
        movement = new Vector2(mx,my).normalized;
        **/
        if (Input.touches.Length > 0)
        {
            Touch currentTouch = Input.touches[0];
            if (currentTouch.phase != TouchPhase.Ended && currentTouch.phase != TouchPhase.Canceled)
            {//Currently Touching the Screen
                Vector3 sTouchPos = currentTouch.position;
                Debug.Log(sTouchPos);
                sTouchPos.z = 1;
                Vector3 wTouchPos = Camera.main.ScreenToWorldPoint(sTouchPos);
                Debug.Log(wTouchPos + " " + rb.position);
                Vector2 wTouchPos2D = new Vector2(wTouchPos.x, wTouchPos.y);
                movement = (wTouchPos2D - rb.position);
                if (movement.magnitude >= .1)
                {
                    movement = movement.normalized;
                }
                else { movement = Vector2.zero; }
            }
            else
            { //Currently not touching the screen
                movement = Vector2.zero;
            }
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    // FixedUpdate is not dependant of framerate (Defaults 50x per second)
    void FixedUpdate(){
        if (moveable){
        rb.velocity =(movement * moveSpeed);
        } else{
            rb.velocity = Vector2.zero;
        }
    }

    public void SetMoveable(bool moveable){
        this.moveable = moveable;
    }
}
