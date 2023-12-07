using UnityEngine;
using UnityEngine.UI;

public class TextPopup : MonoBehaviour
{
    public Text popupText;
    public float displayTime = 2.0f;

    void Start()
    {
        // Hide text initially
        popupText.enabled = false;
    }

    public void ShowPopup(string message)
    {
        // Set the text message
        popupText.text = message;

        // Show the text
        popupText.enabled = true;

        // Invoke a method to hide the text after displayTime seconds
        Invoke("HidePopup", displayTime);
    }

    void HidePopup()
    {
        // Hide the text
        popupText.enabled = false;
    }
}
