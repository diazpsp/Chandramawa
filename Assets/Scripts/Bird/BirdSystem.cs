
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSystem : MonoBehaviour
{
    public float speed;
   
    private Animator anim;
    public Collider2D collDetect;
    private Rigidbody2D bird;
     public float x;
     public float y;
    [SerializeField]private GameObject Player;
     private GameObject point1;
     [SerializeField] float range;
     [SerializeField] float maxDistance;
     [SerializeField]private bool isOnCollider = false;
    //  public Vector2 waypoint;
    //  Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        bird = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
     
        point1 = GameObject.FindGameObjectWithTag("Detect");
        // SetNewDestination();
        Player = GameObject.Find("Chandra");
    }

   

    // Update is called once per frame
    private void FixedUpdate()
    {
       if(isOnCollider){
        StartCoroutine(FlyDirection());
       }
    
    }

                            //INI DETEKSI KANAN KIRINYA ERROR. KETIKA PLAYER NGADEP KANAN DIA IKUT BERENTI, KETIKA PLAYER NGADEP KIRI DIA LANJUT TERBANG. CEK DI FUNGSI FLYAWAY()


    private void FlyAway()
    {
    //    x = Random.Range(-1, 3);
    //    y = Random.Range(0, 3);
        // move = new Vector2(x,y);
        if(gameObject.transform.localScale.x < 0){
        transform.position = Vector2.MoveTowards (transform.position, new Vector2(-6.54f, 13.75f), speed * Time.deltaTime);
        }else{
            transform.position = Vector2.MoveTowards (transform.position, new Vector2(9.56f, 9.53f), speed * Time.deltaTime);
        }
        //  bird.velocity = new Vector2(x * speed *Time.deltaTime,y * speed * Time.deltaTime);
        
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            isOnCollider = true;
            if (Player.transform.localScale.x <0.1){
            gameObject.transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);
            anim.SetTrigger("triggerNear");
            
        }
        else {
            gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        }
        }
    }

    IEnumerator FlyDirection(){
        FlyAway();
        yield return new WaitForSeconds(10f);
        isOnCollider = false;
        // GoToGround();
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
