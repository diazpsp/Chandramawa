using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDetectorTwo : MonoBehaviour
{
     public GameObject player;
   public PlayerController playerCon;
     public FoxSystem Fox;
     public GameObject fox;
    // Start is called before the first frame update
   void Start(){
    player = GameObject.Find("Chandra");
    playerCon = player.GetComponent<PlayerController>();
    fox = GameObject.Find("Fox");
    Fox = fox.GetComponent<FoxSystem>();
   }
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.name == "Chandra"  && playerCon.controllerRigidbody.velocity.magnitude > 0.1f){
            if(Fox.disableRightDetector == false){
                Fox.isRightTrigger = true;
            }
            else{
                Fox.isRightTrigger = false;
            }
        }
    }
}
