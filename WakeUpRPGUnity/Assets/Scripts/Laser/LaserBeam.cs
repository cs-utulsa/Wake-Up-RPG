
/**
 * Created By: Aidan Pohl
 * Created: 02/19/2022
 * 
 * Last Edited By: Aidan Pohl
 * Last Edited: 3/07/2022
 * 
 * Description: Laser Beam propogation
 *
 * 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{   
    /***Variables***/
    [Header("Set In Inspector")]
    public float beamStrength = 100f; //Total length of beam
    public Vector3 localOffset = (Vector3.zero); //0 by default
    public Material beamMaterial;
    public Material beamMaterialWin;
    public float beamWidth =.1f;
    public GameObject lVGOPrefab;
    [Header("Set Dynamically")]
    public GameObject beamGO;
    public LineRenderer beam;      //the visual component of the beam
    public List<float> rLengths;   //remaining lengths after each vertex
    public List<Ray> rays;
    public List<GameObject> vertexes;
    private LayerMask mask;

    //creates a new Beam gameobject with line renderer
    public void MakeBeam(){
        //creates a empty game object for the laser beam
        beamGO = new GameObject("Laser");
        beamGO.tag = "Laser";
        beamGO.transform.SetParent(this.transform);
        beamGO.transform.localPosition = localOffset;
        
        //creates the linerenderer for the visible laser beam
        beam = beamGO.AddComponent<LineRenderer>() as LineRenderer;
        beam.material = beamMaterial;
        beam.startWidth = beamWidth;

        //creates lists for the beam creation and propogation
        rLengths = new List<float>();
        rLengths.Add(beamStrength); //first collision at position 1
        rays = new List<Ray>();
        rays.Add(new Ray(beamGO.transform.position,transform.TransformDirection(Vector3.forward))); //first collision at position 1
        //hits = new List<RaycastHit>(); //first collision at position 0
        vertexes = new List<GameObject>();//first collision as position 0

        ShootBeam();
    }


    //Begins firing the beam from the transform of beamGO.
    public void ShootBeam(){
        beam.positionCount=1;
        rLengths[0] = beamStrength;
        rays[0] = new Ray(beamGO.transform.position,transform.TransformDirection(Vector3.forward));
        beam.SetPosition(0,beamGO.transform.position);

        ShootBeam(1);
        //moves extra vertices away and destroys them
        for(int i = (rays.Count-1); i < vertexes.Count; i++){
            Vector3 pos = vertexes[i].transform.position;
            pos.z += 100;
            vertexes[i].transform.position = pos;
            Destroy(vertexes[i]);
        }
        //trims vertexes
        vertexes = new List<GameObject>(vertexes.GetRange(0,Mathf.Min(vertexes.Count, rays.Count-1)));

    }//end ShootBeam(float length)

    public void ShootBeam(int startPos){
        beam.positionCount=startPos; //Starts beam at position startPos
        rLengths = new List<float>(rLengths.GetRange(0,startPos));
        rays = new List<Ray>(rays.GetRange(0,startPos));
        //hits = new List<RaycastHit>(hits.GetRange(0,startPos-1));

        BeamFire(startPos);
        beam.enabled = true;
    }//end ShootBeam(int startPos)


    //adds a point onto the end of the beam recursively until length is maxed out
    public void BeamFire(int numPoint){
        Ray currRay = rays[numPoint-1];
        Ray nextRay = new Ray();
        float length = rLengths[numPoint-1];
        RaycastHit hit = new RaycastHit();
        Debug.DrawRay(currRay.origin,currRay.direction, Color.white);
        //Checks if the Raycast collides with something
        bool collide = Physics.Raycast(currRay.origin, currRay.direction, out hit, length, mask, QueryTriggerInteraction.Ignore);
        if(collide){//collides
            //hits.Add(hit);
            nextRay.origin = hit.point;
            length -= hit.distance;
            nextRay.direction = Vector3.Reflect(currRay.direction, hit.normal);
        }else{//Does not collide
            nextRay.origin = currRay.origin + (currRay.direction*length);
            length = 0;
        }//if else
        
        rays.Add(nextRay);
        //Adds next point to beam
        beam.positionCount++;
        beam.SetPosition(numPoint,nextRay.origin);
        rLengths.Add(length);

        if(numPoint <= vertexes.Count){
           vertexes[numPoint-1].transform.position = nextRay.origin;
        }else{
            GameObject vertex = Instantiate(lVGOPrefab, nextRay.origin, Quaternion.identity, beamGO.transform);
            vertex.tag = "Laser";
            vertexes.Add(vertex);
        }//end if else

        if(collide && CheckCollisionType(hit) == "Reflective"){ //check if surface is reflective
            BeamFire(numPoint+1);//Recurses ShootBeam at next point
        }//end if(CheckCollisionType(hit) == "Reflective")
    }//end BeamFire(int numPoint)

    public string CheckCollisionType(RaycastHit hit){
        if (hit.transform.gameObject.tag == null){//no collision , returns null
            return "Null";
        }else{//collsion, returns tag
            return hit.transform.gameObject.tag;
        }//end if else
    }//end CheckCollisionType(RaycastHit hit)


    public void Awake(){
        mask = ~LayerMask.GetMask("Ignore Raycast");
        MakeBeam();
    }//end Awake()

    public void Update(){
        //ShootBeam();
        //switch (GameManager.gameState)
        //{
         //   case (GameManager.gameStates.Playing):
        //        ShootBeam();
        //        break;
        //    case (GameManager.gameStates.Idle):
        //        break;
        //    case (GameManager.gameStates.LevelWin):
        //        break;
        //}//end switch case
    }//end Update()

}
