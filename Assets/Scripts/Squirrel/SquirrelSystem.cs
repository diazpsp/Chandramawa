using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelSystem : MonoBehaviour
{
    [SerializeField] private float idleTime;
    [SerializeField] private float toIdle;
    [SerializeField] private float idleToRun;
    [SerializeField] private float forIdleToRun;
    [SerializeField] private float timerStartMoving;
    [SerializeField] private float forTimerStartMoving;

    public GameObject detectorUpRight;
    public GameObject treeIdleDetectorGO;
    public Rigidbody2D rb;
    public float speed;
   
    public bool isDetector = false;
    public bool isDetectorUp = false;
    public bool isNearPlayer = false;
    public bool treeIdleDetector = false;
    public bool startMoving;

    Vector3 rotate;
    Animator anim;
    Vector2 running;
    // Start is called before the first frame update
    void Start()
    {
        detectorUpRight = GameObject.Find("DetectorSquirrel2");
        treeIdleDetectorGO = GameObject.Find("ToIdleDetector");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        detectorUpRight.SetActive(false);
        treeIdleDetectorGO.SetActive(false);
        timerStartMoving = forTimerStartMoving;
    }
    //idletime and to idle is independent

    // Update is called once per frame
    void Update()
    {
        if(startMoving ){
            Runaway();
        }else if(!startMoving && timerStartMoving <0.6f){
            Roam();
        }
       
        if(timerStartMoving>0){
            timerStartMoving -= Time.deltaTime;
            if(timerStartMoving > 0.5f && timerStartMoving < 0.6f){
                startMoving = true;
            }
        }
        
        else
        {   
            // toIdle = 2f;
        }
        NearPlayer();
    }
    void Runaway(){
        idleTime -= Time.deltaTime;
        if(idleTime<=0){
            gameObject.transform.rotation = Quaternion.Euler(0,0,-90);

            running = new Vector2(0,-1* speed)*Time.deltaTime;
            rb.velocity = running;
            anim.SetBool("Run",true);

            if(isDetector){
                // Debug.Log("ko");
                gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                toIdle -= Time.deltaTime;

                running = new Vector2(1* speed,0)*Time.deltaTime;
                rb.velocity = running;
                if(toIdle <=0){
                    // anim.SetBool("Run",false);
                    // running = new Vector2(0,0);
                    // rb.velocity = running;
                    idleToRun = forIdleToRun;
                    startMoving = false;
                    
                }
                else{}
            }
        }
       
    }
    void NearPlayer(){
         //player mendekat dia lari
        if(isNearPlayer){
            if(gameObject.transform.rotation.z < 0){
                running = new Vector2(0,1* speed)*Time.deltaTime;
                rb.velocity = running;
                anim.SetBool("Run",true);
                transform.localScale = new Vector3(-0.55f,0.55f,0.55f);
                treeIdleDetectorGO.SetActive(true);
            }
            else
            {
                running = new Vector2(-1* speed,0)*Time.deltaTime;
                rb.velocity = running;
                anim.SetBool("Run",true);
                transform.localScale = new Vector3(-0.55f,0.55f,0.55f);
                detectorUpRight.SetActive(true);
            }
           
        }
        //jika menyentuh detector di bawah pohon (script detector squirrel up)
        if(isDetectorUp){
                        
            gameObject.transform.rotation = Quaternion.Euler(0,0,-90);
            running = new Vector2(0,1* speed)*Time.deltaTime;
            rb.velocity = running;
            treeIdleDetectorGO.SetActive(true);
        }

        //buat diem di pohon dari lari
        if(treeIdleDetector){
            anim.SetBool("Run",false);
            running = new Vector2(0,0);
            rb.velocity = running;
            timerStartMoving = forTimerStartMoving;
        }
    }

    void Run(){
        if(gameObject.transform.localScale.x >0f){
            running = new Vector2(1* speed,0)*Time.deltaTime;
            rb.velocity = running;
            anim.SetBool("Run",true);
            
            if(idleToRun < 0){
                running = new Vector2(0,0);
                rb.velocity = running;
                anim.SetBool("Run",false);
                if(idleToRun < -2.8f){
                    transform.localScale = new Vector3(-0.55f,0.55f,0.55f);
                    idleToRun = forIdleToRun; 
                    Debug.Log("SEMUANYA");
                }
            }
        }
        else{
            running = new Vector2(-1* speed,0)*Time.deltaTime;
            rb.velocity = running;
            anim.SetBool("Run",true);
            
            if(idleToRun < 0){
                running = new Vector2(0,0);
                rb.velocity = running;
                anim.SetBool("Run",false);
                if(idleToRun < -2.8f){
                    transform.localScale = new Vector3(0.55f,0.55f,0.55f);
                    idleToRun = forIdleToRun;
                }
            }
        }
    }

    void Roam(){
        idleToRun -= Time.deltaTime;
        
            Run();
        
            // anim.SetBool("Run",false);
            // if(idleToRun <3f){
            //     Roam();
            // }
        
    }
//first
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.name =="Chandra"){
            isNearPlayer = true;
        }
        if(coll.gameObject.name =="ToIdleDetector"){
            treeIdleDetector = true;
        }
    }
   
}
