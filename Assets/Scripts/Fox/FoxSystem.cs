using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSystem : MonoBehaviour
{
    public float startWaitTime;
    public float waitTime;
    public float speed;
    public float speedTemp;
    public bool isIdle = false;
    public bool isLeftTrigger = false;
    public bool isRightTrigger = false;
    public bool isMoving = false;
    public bool disableRightDetector = false;
    public Rigidbody2D rb;
    public Animator anim;
    public Transform target;
    public float minimumDistance;
    public float transformStay;
    float accel;
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
        speedTemp = speed;
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
                disableRightDetector = true;
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
                disableRightDetector = false;
            }
            

        }
        else{
           if(isLeftTrigger == true){
                move = new Vector2(7 * speedTemp,0)*Time.deltaTime;
                // move = new Vector2(10,0);
                rb.velocity = move;
                anim.SetBool("Walking",isIdle);
                // rb.AddForce(move*speedTemp * Time.deltaTime);
                transform.localScale =new Vector3(1,1,1) ; 
                StartCoroutine(EAKOS(2));
                disableRightDetector = true;
            }
             if(isRightTrigger == true){
                 move = new Vector2(-7 * speedTemp,0)*Time.deltaTime;
                  rb.velocity = move;
                transform.localScale = new Vector3(-1,1,1) ; 
                // move = new Vector2(-10,0);
                anim.SetBool("Walking",isIdle);
                // rb.AddForce(move*speedTemp * Time.deltaTime);
                StartCoroutine(EAKOS(3));
                Debug.Log("AEas");
            }
            if(!isRightTrigger&&!isLeftTrigger){
                 move = new Vector2(-7 * speedTemp,0)*Time.deltaTime;
                  rb.velocity = move;
                transform.localScale = new Vector3(-1,1,1) ; 
                // move = new Vector2(-10,0);
                anim.SetBool("Walking",isIdle);
                // rb.AddForce(move*speedTemp * Time.deltaTime);
                StartCoroutine(EAKOS(5));
                Debug.Log("EA");
            }
        }
    }
    void Update(){
        // if(Vector2.Distance(transform.position, target.position) < minimumDistance){

        // }
        if(isMoving == true && transform.localScale.x == -1 && isLeftTrigger){
            //kok TRUE semua ya bool nya?
            
            StartCoroutine(ChangetoRight());
           

        }
    }

    IEnumerator ChangetoRight(){
        // speedTemp = 0; 
        // move = new Vector2(0,0);
        // Debug.Log("sped 0");
        //      rb.AddForce(move*0*Time.deltaTime);
        //       transform.localScale =new Vector3(1,1,1) ; 
         yield return new WaitForSeconds(1f);
        //   speedTemp = speed; 
        //          move = new Vector2(10,0);
           
        //     rb.AddForce(move*speedTemp * Time.deltaTime);
            Debug.Log(":Sea");
    }
    IEnumerator EAKOS(float time){
        yield return new WaitForSeconds(time);
        isIdle = false;
        isLeftTrigger = false;
        anim.SetBool("Walking",isIdle);
        Debug.Log("MASOK EAKOS");
    }

    // void Turn(){
    //     accel = rb.velocity.magnitude;
    //     if(accel < 0.5f){
    //         transformStay = transform.position.x;
    //         if()
    //         
    //         Debug.Log("KIRI YU");
    //     }
    //     if(){
    //         transform.localScale = new Vector3(1,1,1) ; 
    //         Debug.Log("KAANNAAn");
    //     }
    // }

    // IEnumerator IdleTime(){

    //   if(Vector2.Distance(transform.position, target.position) < minimumDistance){
    //     isIdle = true;
    //   }else{
    //     yield return new WaitForSeconds(2f);
    //     isIdle = true;
    //   }
    // }
}
