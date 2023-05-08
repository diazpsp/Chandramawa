using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBirdPoint : MonoBehaviour
{
    public bool isChandraHere = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D coll){
        if(coll.gameObject.name=="Chandra"){
            isChandraHere = true;
        }

    }
    void OnTriggerExit2D(Collider2D coll){
        if(coll.gameObject.name == "Chandra"){
            isChandraHere = false;
        }
    }
}
