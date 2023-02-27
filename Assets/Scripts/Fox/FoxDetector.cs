using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDetector : MonoBehaviour
{
   
     public FoxSystem Fox;
     public GameObject fox;
    // Start is called before the first frame update
   void Start(){
    fox = GameObject.Find("Fox");
    Fox = fox.GetComponent<FoxSystem>();
   }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            Fox.isLeftTrigger = true;
            Debug.Log("Ae");
        }
    }
}
