using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour, IInteractable
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, container, fpsCam;
    public Interactor interact;

    public float pickUpRange;
    public float dropForwardFroce, dropUpwardForce;
    public float rotateAmmount;

    public bool equipped;
    public static bool slotfull;

    // Start is called before the first frame update
    void Start()
    {
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotfull = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }
    public void Interact()
    {
        equipped = true;
        slotfull = true;

        transform.SetParent(container);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(0, 0, rotateAmmount);

        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    private void Drop()
    {
        equipped = false;
        slotfull = false;

        rb.isKinematic = false;
        coll.isTrigger = false;

        transform.localRotation = Quaternion.Euler(0, 0, 0);

        transform.SetParent(null);

        //rb.velocity = player.GetComponent<Rigidbody>().velocity;

        rb.AddForce(fpsCam.forward * dropForwardFroce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);

        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
    }
}
