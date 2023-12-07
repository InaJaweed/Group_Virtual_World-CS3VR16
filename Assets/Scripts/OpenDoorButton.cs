using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour, IInteractable
{

    public Animation Anim;
    public BoxCollider coll;

    public bool open;

    public void Interact()
    {
        if (!open)
        {
            open = true;
            Anim.Play("Door_Open");
            coll.isTrigger = true;
        }

    }
}
