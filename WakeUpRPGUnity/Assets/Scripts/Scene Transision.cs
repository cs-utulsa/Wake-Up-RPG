using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransision : MonoBehaviour
{
    //private arrayList<string> backgroundList = 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * fairly simple implementation at the moment, full script not needed may combine into gameManager
     * could create an arrayList of backgrounds and people per day from total to speedup process but may in fact be slower
     * possible future goals that could warrent methods and script:
     * * for background transitions should find a way to give a black screen for half a second to not disorient audience
     * * with time, add animations for entering and leaving of sprites like blur between rooms or pop up and down for objects and characters
     */

    //for when one sprite gets replaced with another of same level / priority
    public void ChangeSprite(GameObject oldSprite, GameObject nextSprite)
    {
         oldSprite.SetActive(false);
        nextSprite.SetActive(true);
        //may need to work on the layering so places do not 
    }

    //for when a scene ends entirely
    public void disposeSprite(GameObject oldSprite)
    {
        oldSprite.SetActive(false);
    }

    //for when a scene begins entirely
    public void enterSprite(GameObject nextSprite)
    {
        nextSprite.SetActive(true);
    }
}
