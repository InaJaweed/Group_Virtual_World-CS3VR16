using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public AudioSource Scream;


    private void OnTriggerEnter()
    {
        Debug.Log("JUMP SCARE TRIGR");
        Scream.Play();
        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.03f);
    }
}
