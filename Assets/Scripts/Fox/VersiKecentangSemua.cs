using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersiKecentangSemua : MonoBehaviour
{
                                        // TAPI BOONGGGG. INI VERSI NORMAL DARI KANAN
   public float startWaitTime;
    public float waitTime;
    public float speed;
    public bool isIdle = false;
    public bool isLeftTrigger = false;
    public bool isRightTrigger = false;
    public Rigidbody2D rb;
    public Animator anim;
    public Transform target;
    public float minimumDistance;
    // RaycastHit2D hit;
    // RaycastHit2D hit2;
    // public float distance;
    Vector2 move;
    // Start is called before the first frame update
    void Awake()
    {
        waitTime = startWaitTime;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // target = GameObject.Find("Chandra");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // hit = Physics2D.Raycast(transform.position,transform.right,distance);
        // hit2 = Physics2D.Raycast(transform.position,-transform.right,distance);

        // if(hit2.collider.tag == "Player"){
        //     Debug.DrawRay(transform.position,hit2.point,Color.red);
        //     Debug.Log("hit");
        // }
        if (!isIdle){
            // if(Vector2.Distance(transform.position, target.position) < minimumDistance){
            //     isIdle = true;
            //     waitTime = startWaitTime;
                
            // }
            if(isLeftTrigger){
               isIdle = true;
                waitTime = startWaitTime;
            }
             if(isRightTrigger){
              isIdle = true;
                waitTime = startWaitTime;
            }
           
            
            if(waitTime<=0){
                isIdle = true;
                waitTime = startWaitTime;
            }else{
                waitTime -= Time.deltaTime;
            }
            

        }
        else{
           if(isLeftTrigger){
                move = new Vector2(10,0);
                anim.SetBool("Walking",isIdle);
                rb.AddForce(move*speed * Time.deltaTime);
                
            }
             if(isRightTrigger){
                move = new Vector2(-10,0);
                anim.SetBool("Walking",isIdle);
                rb.AddForce(move*speed * Time.deltaTime);
                
            }
            else{
                move = new Vector2(-10,0);
                anim.SetBool("Walking",isIdle);
                rb.AddForce(move*speed * Time.deltaTime);
            }
        }
    }
    void Update(){
        // if(Vector2.Distance(transform.position, target.position) < minimumDistance){

        // }
    }

    // IEnumerator IdleTime(){

    //   if(Vector2.Distance(transform.position, target.position) < minimumDistance){
    //     isIdle = true;
    //   }else{
    //     yield return new WaitForSeconds(2f);
    //     isIdle = true;
    //   }
    // }
}
