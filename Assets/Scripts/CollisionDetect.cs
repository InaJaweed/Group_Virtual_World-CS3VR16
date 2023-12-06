using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public BoxCollider coll;
    public string tTag;

    // Start is called before the first frame update
    void Start()
    {
        coll.isTrigger = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding GameObject has the specified tag
        if (other.CompareTag(tTag))
        {
            coll.isTrigger = true;
        }
    }
}
