using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSystem : MonoBehaviour
{
    public float speed;
    bool isIdle = false;
    public Rigidbody2D rb;
    public Animator anim;
    Vector2 move;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isIdle){
            StartCoroutine(IdleTime());
        }
        else{

        anim.SetBool("Walking",isIdle);
        rb.AddForce(move*speed * Time.deltaTime);
        }
    }
    void Update(){
        move = new Vector2(-10,0);
    }

    IEnumerator IdleTime(){

    
        yield return new WaitForSeconds(2f);
        isIdle = true;
    }
}
