using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueHandler : MonoBehaviour
{
    public int[] answer;
    public string text;

    public List<int> input;
    public GameObject go;
    public AudioSource audioSourceCorrect;
    public AudioSource audioSourceIncorrect;
    public TextPopup textPopupScript;

    void Start()
    {
        answer = new int[] { 1, 2, 3 };
        input = new List<int>(answer.Length);
    }

    public void CheckAnswer()
    {
        bool isCorrect = true;

        for (int i = 0; i < answer.Length; i++)
        {
            if (i < input.Count && input[i] != answer[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            audioSourceCorrect.Play();
            textPopupScript.ShowPopup(text);
            Debug.Log("Puzzle Solved!");
            go.GetComponent<DoorAnimator>().unlocked = true;
            // Handle puzzle completion logic here
        }
        else
        {
            audioSourceIncorrect.Play();
            Debug.Log("Incorrect sequence. Resetting...");
        }
    }
}
