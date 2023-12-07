using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour, IInteractable
{
    public GameObject destroyedVersion;

    public Quaternion rotation;

    public void Interact()
    {
        DestoryObject(rotation);
    }

    public void DestoryObject(Quaternion rotation)
    {
        Instantiate(destroyedVersion, new Vector3(transform.position.x, 1, transform.position.z), rotation);
        Destroy(gameObject);
    }
}
