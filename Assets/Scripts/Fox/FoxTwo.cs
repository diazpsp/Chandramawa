using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxTwo : MonoBehaviour
{
    private Rigidbody2D rb;
    public float distance;
   public float speed;
    public Transform target;
    public Transform playerTrans;
    Vector2 move;
    public Vector2 direction;
    public PlayerController playerCon;
    public float accel;
    public bool isIdle = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playerCon = GameObject.Find("Chandra").GetComponent<PlayerController>();
        target = GameObject.Find("FoxCore").transform;
        playerTrans = GameObject.Find("Chandra").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // distance = target.InverseTransformPoint(playerTrans.position);
        distance = target.transform.position.x - playerTrans.transform.position.x;
        // direcitonXNumber = direction.x;
         accel = rb.velocity.magnitude;
            anim.SetFloat("Speed",accel);
        if(distance >= -4f && distance < 0f && playerCon.controllerRigidbody.velocity.magnitude > 0.5f){
            isIdle = true;
             transform.localScale = new Vector3(-1,1,1) ; 
             
            move = new Vector2(-6* speed ,0)*Time.deltaTime;
           rb.velocity = move;
            
        }
        if(distance <= 4f && distance >= 0f && playerCon.controllerRigidbody.velocity.magnitude > 0.5f){
             isIdle = true;
             transform.localScale = new Vector3(1,1,1) ; 
            
            move = new Vector2(6* speed ,0)*Time.deltaTime;
            rb.velocity = move;
            
        }else{
             isIdle = false;
             
              
             transform.Translate(new Vector2(0f,0f) *Time.deltaTime, Space.Self);
             Debug.Log("WOISTOP");
        }
    }
}
