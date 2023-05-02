using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelSystem : MonoBehaviour
{
    [SerializeField] private float idleTime;
    [SerializeField] private float toIdle;

    public GameObject detectorUpRight;
    public GameObject treeIdleDetectorGO;
    public Rigidbody2D rb;
    public float speed;
   
    public bool isDetector = false;
    public bool isDetectorUp = false;
    public bool isNearPlayer = false;
    public bool treeIdleDetector = false;

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
        }
        

    }


    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.name =="Chandra"){
            isNearPlayer = true;
        }
        if(coll.gameObject.name =="ToIdleDetector"){
            treeIdleDetector = true;
        }
    }
   
}
