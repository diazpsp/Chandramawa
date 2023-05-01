using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorSquirrelUp : MonoBehaviour
{
    public GameObject sqrlObject;
    public SquirrelSystem sqrlSys;
    
    // Start is called before the first frame update
    void Start()
    {
        sqrlObject = GameObject.Find("Squirrel (1)");
        sqrlSys = sqrlObject.GetComponent<SquirrelSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject.name == "Squirrel (1)"){
            sqrlSys.isDetectorUp = true;
            Debug.Log("detectorup");
        }

    }
}
