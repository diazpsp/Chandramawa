using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelSystem : MonoBehaviour
{
    [SerializeField] private float idleTime;
    [SerializeField] private float toIdle;

    public GameObject detectorUpRight;
    public Rigidbody2D rb;
    public float speed;
   
    public bool isDetector = false;
    public bool isDetectorUp = false;
    public bool isNearPlayer = false;

    Vector3 rotate;
    Animator anim;
    Vector2 running;
    // Start is called before the first frame update
    void Start()
    {
        detectorUpRight = GameObject.Find("DetectorSquirrel2");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        detectorUpRight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         

        idleTime -= Time.deltaTime;
        if(idleTime<=0){
            gameObject.transform.rotation = Quaternion.Euler(0,0,-90);

            running = new Vector2(0,-1* speed)*Time.deltaTime;
            rb.velocity = running;
            anim.SetBool("Run",true);

            if(isDetector){
                Debug.Log("ko");
                gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                toIdle -= Time.deltaTime;

                running = new Vector2(1* speed,0)*Time.deltaTime;
                rb.velocity = running;
                if(toIdle <=0){
                    anim.SetBool("Run",false);
                    running = new Vector2(0,0);
                     rb.velocity = running;
                }
            }
        }
        if(isNearPlayer){
            running = new Vector2(-1* speed,0)*Time.deltaTime;
            rb.velocity = running;
            anim.SetBool("Run",true);
            transform.localScale = new Vector3(-0.55f,0.55f,0.55f);
            detectorUpRight.SetActive(true);

           
        }
        if(isDetectorUp){
                        
                        gameObject.transform.rotation = Quaternion.Euler(0,0,-90);
                        running = new Vector2(0,1* speed)*Time.deltaTime;
                        rb.velocity = running;
                    }
        
        

    }


    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.name =="Chandra"){
            isNearPlayer = true;
        }
    }
   
}
