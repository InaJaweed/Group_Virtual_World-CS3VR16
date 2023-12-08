using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueHandler : MonoBehaviour
{
    public int[] answer;
    public string text;
    public bool correct;

    public List<int> input;
    public GameObject go;
    public AudioSource audioSourceCorrect;
    public AudioSource audioSourceIncorrect;
    public TextPopup textPopupScript;

    void Start()
    {
        answer = new int[] { 1, 2, 3 };
        input = new List<int>(answer.Length);
        correct = false;
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

        if (isCorrect && !correct)
        {
            audioSourceCorrect.Play();
            textPopupScript.ShowPopup(text);
            Debug.Log("Puzzle Solved!");
            go.GetComponent<DoorAnimator>().unlocked = true;
            correct = true;

        }
        else if (correct)
        {

        }
        else
        {
            audioSourceIncorrect.Play();
            Debug.Log("Incorrect sequence. Resetting...");
        }
    }
}
