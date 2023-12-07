using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class NoteController : MonoBehaviour, IInteractable
{

    [Header("UI Text")]
    [SerializeField] GameObject noteCanvas;
    [SerializeField] private TMP_Text noteTextAreaUI;

    [Space(10)]
    [SerializeField][TextArea] private string noteText;

    [Space(10)]
    [SerializeField] private UnityEvent openEvent;
    private bool isOpen = false;

    public void Interact()
    {
        ShowNote();
    }
    public void ShowNote()
    {
        Debug.Log("IT IS OPEN");
        isOpen = true;
        noteTextAreaUI.text = noteText;
        noteCanvas.SetActive(true);
        openEvent.Invoke();
        //DisablePlayer(true);
       
    }
    void DisableNote()
    {
        //Debug.Log("DisableNote method is called.");
        noteCanvas.SetActive(false);
        //DisablePlayer(false);
        isOpen = false;
    }

    /*void DisablePlayer(bool disable)
    {
        player.enabled = !disable;
    }*/

    private void Update()
    {
        //Debug.Log("Update is called and note is open.");
        if (isOpen)
        {
            //Debug.Log("Update is called and note is open.");

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Q key is pressed.");
                DisableNote();
            }
        }
    }

}
