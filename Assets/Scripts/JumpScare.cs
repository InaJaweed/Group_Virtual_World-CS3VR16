using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScare : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject Jumpcam;
    

    private void OnTriggerEnter()
    {
        Debug.Log("JUMP SCARE TRIGGER");
        Scream.Play();
        Jumpcam.SetActive(true);
        
        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.03f);
        Jumpcam.SetActive(false);
       
        // Load the new scene after the jump scare
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
