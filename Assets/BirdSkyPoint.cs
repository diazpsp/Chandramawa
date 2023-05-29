using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSkyPoint : MonoBehaviour
{
    public bool birdIsHere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject){
            birdIsHere = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll){
        if(coll.gameObject){
            birdIsHere = false;
        }
    }
}
