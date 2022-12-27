
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

     private GameObject point1;
     [SerializeField] float range;
     [SerializeField] float maxDistance;
    //  public Vector2 waypoint;
    //  Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        bird = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
     
        point1 = GameObject.FindGameObjectWithTag("Detect");
        // SetNewDestination();
    }

   

    // Update is called once per frame
    void Update()
    {
       
    
    }

    private void FlyAway()
    {
       x = Random.Range(-1, 3);
       y = Random.Range(0, 3);
        // move = new Vector2(x,y);
        if (x <0){
            gameObject.transform.localScale = new Vector3(-0.15f, 0.15f, 0.15f);
        }
        else {
            gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        }

         bird.velocity = new Vector2(x * speed *Time.deltaTime,y * speed * Time.deltaTime);
        
        anim.SetTrigger("triggerNear");
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            StartCoroutine(FlyDirection());
        }
    }

    IEnumerator FlyDirection(){
        FlyAway();
        yield return new WaitForSeconds(2);
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
