using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSystem : MonoBehaviour
{
    public float speed;
   
    private Animator anim;
    public Collider2D collDetect;
    private Rigidbody2D bird;
    public GameObject firstBirdPoint;
    public Transform playerTransB;
    public FirstBirdPoint firstPoint;
    
    // public GameObject firstPointGO;
    public float timerForReturn;
    public float timerForChangeDir;
    public float forTimer;
    public float forTimerChangeDir;
    public bool isFlyingRight; //coba set pivate debug isflyingright
    [SerializeField]private bool boole = false; // untuk mengeksekusi command terbang kembali ke tanah
   
    public float distancebirdtoplayer;
    public float distancebirdtoPlayerY;
    [SerializeField]private GameObject Player;
     private GameObject point1;
     [SerializeField] float range;
     [SerializeField] float maxDistance;
     [SerializeField]private bool apakahTerbang = false;
     [SerializeField]private bool isOnCollider = false;
     
     [SerializeField]private bool boool; // untuk memutar burungnya saat sdh sampai titik atas. setlh diputar, lalu dia terbang kebawah
      
     Vector2 running;


                                                //protected itu bisa diakses class inheritancenya. private tak bisa(hanya 1 class saja)
    //  public Vector2 waypoint;
    //  Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        bird = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // firstBirdPoint.SetActive(false);
        point1 = GameObject.FindGameObjectWithTag("Detect");
        // SetNewDestination();
        playerTransB = GameObject.Find("Chandra").transform;
        Player = GameObject.Find("Chandra");
        // firstPointGO = GameObject.Find("1stBirdPoint");
        // firstPoint = GetComponent<FirstBirdPoint>();
    }

   

    // Update is called once per frame
    private void FixedUpdate()
    {
       if(isOnCollider){
        FlyAway();
       }

    //    if(skyPoint.birdIsHere){
    //     boool = true;
    //    }else if(!skyPoint.birdIsHere){
    //     boool = false;
    //    }
        distancebirdtoplayer = gameObject.transform.position.x - playerTransB.transform.position.x;
        distancebirdtoPlayerY = gameObject.transform.position.y - playerTransB.transform.position.y;
    }
    void Update(){
        Condition();
       
        Debug.Log(apakahTerbang+"isflying");
        Debug.Log(boole+"boole");
        Debug.Log(boool+"boooool");
        // Debug.Log(isOnCollider+"isoncollid");

        if(distancebirdtoPlayerY>15){
            boool=true;
            
        }else{boool=false;}
    }
             

    private void FlyAway()
    {
    //    x = Random.Range(-1, 3);
    //    y = Random.Range(0, 3);
        // move = new Vector2(x,y);
        
        //  bird.velocity = new Vector2(x * speed *Time.deltaTime,y * speed * Time.deltaTime);
        
        timerForReturn -= Time.deltaTime;
        timerForChangeDir -= Time.deltaTime;
        if(timerForReturn>1){
            FlyToDirection();
            // StartCoroutine(Boool());
       
            Debug.Log("FLYAWAY ATAS");
        }else if(timerForChangeDir> 1){
            FlyDirection2();
        }else if(timerForChangeDir<0 && timerForReturn <0){
            firstBirdPoint.SetActive(true);
            StartCoroutine(TurningToGround());
         
        }
        
    }
    //decides where to fly when player near the bird for the first time
    public void FlyToDirection(){
        if(gameObject.transform.localScale.x < 0){
            transform.position = Vector2.MoveTowards (transform.position, new Vector2(-12.8f,23.99f), speed * Time.deltaTime);
           
            boole = false;
        }else{
            transform.position = Vector2.MoveTowards (transform.position, new Vector2(36.93f, 22.97f), speed * Time.deltaTime);
            
            boole = false;
          
        }
    }

    // IEnumerator Boool(){
    //     yield return new WaitForSeconds(7f);
    //     boool = true;
        
    //     yield return new WaitForSeconds(0.5f);
    //     Debug.Log("AS");
    // }

   
    public void FlyBack(){
        //jika player masih di pointnya buruing, maka burung tidak akan terbang kebawah, tetapi jika player telah meninggalkan collider point baliknya burung, maka burung akan terbang ke point tsb walaupun player masuk ke collider 1stBirdPoint nya lagi.
        if(!firstPoint.isChandraHere){
             boole = true;
            //  boool = true;
         
            ///buat ngasih hadap burungnya
            if(!isFlyingRight && boool){
                Turning(0.4f);
                Debug.Log("turning 0.4");
                // boool = false;
            }else if (isFlyingRight && boool){
                Turning(-0.4f);
                Debug.Log("turning -0.4");
                // boool = false;
                
            }else{}
        } 
         if (boole){
                transform.position = Vector2.MoveTowards (transform.position, firstBirdPoint.transform.position, speed * Time.deltaTime);
                // boool = false;
            }
        
        //kontradiksi disini ( atas bawah)

    } 
    private void Turning(float scaleX){
         if(scaleX>0.3f){
            gameObject.transform.localScale = new Vector3(-0.4f,0.4f,0.4f);
        }else{
            gameObject.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Chandra"){
            
                
        }
        if(col.gameObject.name == "1stBirdPoint"){
            
            anim.SetBool("isFlying",false);
            apakahTerbang = false;
        }
        if(col.gameObject.name == "BirdSkyPointLeft"){
            isFlyingRight = true;
            Debug.Log("BIRDPOINTLEFt");
        }
        if(col.gameObject.name == "BirdSkyPointRight"){
            isFlyingRight = false;
            Debug.Log("BIRDPOINTRight");
        }
    }

     IEnumerator TurningToGround(){
        FlyBack();
        Debug.Log("IENUM");
        
        yield return new WaitForSeconds(0.4f);
        Debug.Log("ENEm");
        
    }

    //kepake di BIrdDirection
    IEnumerator FlyDirection(){
        
        yield return new WaitForSeconds(2f);
        apakahTerbang = true;
        // if(isFlyingRight){
        //     isFlyingRight = false;
            // boool = true;
            // Debug.Log("FD ATAS");
        // }else{
        //     isFlyingRight = true;
            // boool = true;
            // Debug.Log("FD BAWAH");
        // }
        // isOnCollider = false;
        // GoToGround();
    }

    //lalu untuk yg kedua kalinya kesini
    void BirdDirection(){
        //menentukan arah burung terbang dengan menentukan dia hadap mana untuk pertama kali.

                if (distancebirdtoplayer >= 0f && distancebirdtoplayer <=4f ){
                    gameObject.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
                    isFlyingRight = true;
                    timerForReturn = forTimer;
                    isOnCollider = true;
                    StartCoroutine(FlyDirection());
                    anim.SetBool("isFlying",true);
                    // if(distancebirdtoplayer >= 0f && distancebirdtoplayer <=4f && gameObject.transform.position.y <= -8.41f){
                    //     timerForReturn = forTimer;
                    //     isOnCollider = true;
                    // Debug.Log("aTAS");
                    //     anim.SetBool("isFlying",true);
                    // }
                }
                if(distancebirdtoplayer >= -4f && distancebirdtoplayer <0f ) {
                    gameObject.transform.localScale = new Vector3(-0.4f,0.4f,0.4f);
                    timerForReturn = forTimer;
                    isOnCollider = true;
                    isFlyingRight = false;
                    StartCoroutine(FlyDirection());
                    anim.SetBool("isFlying",true);
                  
                }
    }
    // void IsItFlying(){
    //     if(distancebirdtoPlayerY>7.5f){
    //                 apakahTerbang = true;
    //             }
    //             else{
                   
    //             }
    // }

    //ketika dari atas mau kebawah, tapi ketemu player
    void BirdChangeDirection(){
        if(distancebirdtoplayer >= -4f && distancebirdtoplayer <=4f && distancebirdtoPlayerY >=-3f && distancebirdtoPlayerY <=7f){
            boole = false;
            // boool = false;
            if(!isFlyingRight){
                gameObject.transform.localScale = new Vector3(-0.4f,0.4f,0.4f);
                timerForChangeDir = forTimerChangeDir;
           
                 
                // StartCoroutine(FlyDirection());
                
                anim.SetBool("isFlying",true);
            }else if(isFlyingRight){
                gameObject.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
                timerForChangeDir = forTimerChangeDir;
                
                
                anim.SetBool("isFlying",true);
            }
        }
    }

    //untuk menentukan movetowards mana pada BChangeDir
    void FlyDirection2(){
        if(gameObject.transform.localScale.x < 0){
            transform.position = Vector2.MoveTowards (transform.position, new Vector2(-12.8f,23.99f), speed * Time.deltaTime);
            
           
        }else{
            transform.position = Vector2.MoveTowards (transform.position, new Vector2(36.93f, 22.97f), speed * Time.deltaTime);
            
       
          
        }
    }
    //menanyakan apakah ia dalam kondisi terbang atau tidak
    // kondisi mengecek PERTAMA KALI / FIRST TIME CHECK
    void Condition(){
        if(!apakahTerbang){
            BirdDirection();
            Debug.Log("Atas");
            // IsItFlying();
               
        }else if(apakahTerbang) {
            BirdChangeDirection();
            Debug.Log("bawah");
        }else{}
        
    }
    // private void GoToGround(){
    //     if (point1 == null)
    //         return;
    //     Debug.Log("soe");
    //     bird.velocity = Vector2.MoveTowards(transform.position, point1.transform.position,speed * Time.deltaTime);
    //     if(transform.position == point1.transform.position){
    //         anim.SetTrigger("triggerIdle");
    //         Debug.Log("soeawe");
    //     }
    // }

    // private void SetNewDestination()
    // {
    //     waypoint = new Vector2(Random.Range(-maxDistance, maxDistance),6);
    // }
}