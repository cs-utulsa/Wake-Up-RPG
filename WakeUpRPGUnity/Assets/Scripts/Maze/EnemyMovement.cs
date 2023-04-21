
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 2f;
    private Transform target;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 2f;
    [SerializeField] private float canAttack = 1f;
    GameObject timer;
    
    
    void Awake(){
        timer = GameObject.Find("Timer");
    }
    void FixedUpdate(){
        if (target !=  null){
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,target.position, step);
        }
    }

    private void OnCollisionStay2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            if (attackSpeed <= canAttack){
            //timer.GetComponent<CountDownTimer>().UpdateTimer(-attackDamage);
            canAttack = 0;
        }else {
            canAttack += Time.fixedDeltaTime;
        }
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
        target = other.transform;
        }
    }

     private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            target = null;
       }
    } 

    public void SetTarget(Transform newTarget){
        target = newTarget;
    }
}
