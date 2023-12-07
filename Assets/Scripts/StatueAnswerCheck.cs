using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueAnswerCheck : MonoBehaviour, IInteractable
{
    public int statueNumber;

    private int[] answer;
    private List<int> input;

    void Start()
    {
        answer = new int[] { 1, 2, 3 };
        input = new List<int>(answer.Length);
    }

    public void Interact()
    {
        if (input.Count < answer.Length)
        {
            int pressedStatue = Press();
            input.Add(pressedStatue);

            Debug.Log("Input List: " + string.Join(", ", input));

            // Check if the input list has reached the required length
            if (input.Count == answer.Length)
            {
                CheckAnswer();
                // Clear input for the next attempt
                input.Clear();
            }
        }
    }

    public int Press()
    {
        Debug.Log("Statue pressed: " + statueNumber);
        return statueNumber;
    }

    void CheckAnswer()
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
            Debug.Log("Puzzle Solved!");
            // Handle puzzle completion logic here
        }
        else
        {
            Debug.Log("Incorrect sequence. Resetting...");
        }
    }
}
