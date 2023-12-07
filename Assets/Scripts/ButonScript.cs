using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonScript : MonoBehaviour, IInteractable
{
    public int StatueNumber;

    public void Interact()
    {
        Press();
    }

    public int Press()
    {
        Debug.Log("Statue pressed: " + StatueNumber);
        return StatueNumber;
    }
}
