
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface AActivate
{
    void Activate(Collider other);
}

public class CollisionDetect : MonoBehaviour
{
    //public BoxCollider coll;
    public string tTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        AActivate activateInterface = gameObject.GetComponent<AActivate>();

        if (activateInterface != null)
        {
           activateInterface.Activate(other);
           //Debug.Log("Activated!");
        }
        else
        {
            //Debug.Log("Null");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        AActivate activateInterface = gameObject.GetComponent<AActivate>();

    }
}