using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorAnimator : MonoBehaviour, AActivate { 

    public Animation Anim;
    public BoxCollider coll;

    public string tTag;
    public bool unlocked;
    public bool requiresKey;
    public bool open;

    public void Start()
    {
        if (requiresKey)
        {
            unlocked = false;
        }

        open = false;
    }

    public void Activate(Collider other)
    {
        if (!open) // Check if the door is not already open
        {
            if (requiresKey && other.CompareTag("Key") && !unlocked)
            {
                // If a key is required and the door is locked, unlock it
                unlocked = true;
            }

            if (!requiresKey || (requiresKey && unlocked))
            {
                // If no key is required or the door is unlocked, open the door
                coll.isTrigger = true;
                open = true;
                Anim.Play("Door_Open");
            }
        }
    }

    public void Deactivate(Collider other)
    {
        /*
        if (unlocked)
        {
            Anim.Play("Door_Close");
        }
        */
    }
}