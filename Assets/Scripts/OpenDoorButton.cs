using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour, IInteractable
{

    public Animation Anim;
    public TextPopup textPopupScript;
    public GameObject go;
    public string text;

    //public bool open;

    public void Interact()
    {
        if (!go.GetComponent<DoorAnimator>().unlocked)
        {
            go.GetComponent<DoorAnimator>().unlocked = true;
            textPopupScript.ShowPopup(text);
        }

    }
}
