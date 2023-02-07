using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFloor : MonoBehaviour
{
    [SerializeField] GameObject floor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecolorByDistance(int distToExit){
       
        floor.GetComponent<SpriteRenderer>().color = new Color(.9f - (.25f*distToExit),.9f - (.25f*distToExit),.9f - (.25f*distToExit));
    }

}
