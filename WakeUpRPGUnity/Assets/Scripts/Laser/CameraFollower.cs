using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{   
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
    InstantFocus();
    }

    // Update is called once per frame
    void Update()
    {   if (target != null)
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(target.position.x,target.position.y,-20),30*Time.deltaTime);
    }

    public void SetTarget(Transform other){
        target = other;
    }

    public void InstantFocus()
    {
        transform.position = new Vector3(target.position.x, target.position.y, -20);
    }
}
