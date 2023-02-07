using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemies : MonoBehaviour
{   System.Random rand = new System.Random(System.DateTime.Now.Millisecond);
    [SerializeField] GameObject meleeEnemy;
    public bool allowEnemies = true;
    GameObject[] mummies;
    Vector3[] mummySpawnLoc;
    int numEnemies;
    // Start is called before the first frame update
    public void genEnemies()
    {   if(allowEnemies){
            numEnemies = rand.Next(3);
            mummies = new GameObject[numEnemies];
            mummySpawnLoc = new Vector3[numEnemies];
            for (int i=0; i< numEnemies;i++){
                mummySpawnLoc[i] = new Vector3(transform.position.x+(rand.Next(5)-2.5f),transform.position.y+(rand.Next(5)-2.5f),transform.position.z-1);
                mummies[i] = Instantiate(meleeEnemy, mummySpawnLoc[i], Quaternion.identity, transform);
                mummies[i].SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            for (int i = 0; i < numEnemies; i++){
                mummies[i].transform.position = mummySpawnLoc[i];
                mummies[i].SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            for(int i = 0; i< numEnemies; i++){
                mummies[i].SetActive(false);
            }
        }
    }

    public void enableEnemies(bool enable){
        allowEnemies = enable;
    }
}
