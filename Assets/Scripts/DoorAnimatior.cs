using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorAnimator : MonoBehaviour, AActivate { 

    public Animation Anim;
    public BoxCollider coll;
    public TextPopup textPopupScript;
    public AudioSource audioDoorOpening;
    //public PickUpController pickUpController;

    public string tTag;
    public bool unlocked;
    public bool requiresKey;
    public bool open;
    public string text;

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
                other.GetComponent<PickUpController>().Drop();
                Destroy(other);

            }

            if (!requiresKey || (requiresKey && unlocked))
            {
                // If no key is required or the door is unlocked, open the door
                audioDoorOpening.Play();
                coll.isTrigger = true;
                open = true;
                Anim.Play("Door_Open");
            }
            else if(!coll.isTrigger)
            {
                textPopupScript.ShowPopup(text);

            }
        }
    }

    public void Update()
    {
        if (unlocked && !open)
        {
            audioDoorOpening.Play();
            coll.isTrigger = true;
            open = true;
            Anim.Play("Door_Open");
        }
    }
}