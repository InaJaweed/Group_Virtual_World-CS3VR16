using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScare : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject Jumpcam;
    public GameObject player;

    private void OnTriggerEnter()
    {
        Debug.Log("JUMP SCARE TRIGGER");
        Scream.Play();
        Jumpcam.SetActive(true);
        player.SetActive(false);
        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.03f);
        Jumpcam.SetActive(false);
        player.SetActive(true);
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
