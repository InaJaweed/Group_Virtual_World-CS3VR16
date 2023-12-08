using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowController : MonoBehaviour
{
    public TextPopup textPopup;

    public string text;

    private void OnTriggerEnter()
    {
        textPopup.ShowPopup(text);

    }
}
