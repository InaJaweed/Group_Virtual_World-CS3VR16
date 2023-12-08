using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour, IInteractable
{
    public GameObject destroyedVersion;
    public AudioSource Break;
    public TextPopup textPopupScript;

    public string text;

    public Quaternion rotation;

    public void Interact()
    {
        Break.Play();
        if(textPopupScript != null)
        {
            textPopupScript.ShowPopup(text);
        }
        else
        {

        }
        DestoryObject(rotation);
    }

    public void DestoryObject(Quaternion rotation)
    {
        Instantiate(destroyedVersion, new Vector3(transform.position.x, 1, transform.position.z), rotation);
        Destroy(gameObject);
    }
}
