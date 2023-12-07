using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatueAnswerCheck : MonoBehaviour, IInteractable
{
    public int statueNumber;

    public StatueHandler statueHandler;

    private void Start()
    {
        statueHandler = FindObjectOfType<StatueHandler>();
    }
    public void Interact()
    {
        if (statueHandler.input.Count < statueHandler.answer.Length)
        {
            int pressedStatue = Press();
            statueHandler.input.Add(pressedStatue);

            Debug.Log("Input List: " + string.Join(", ", statueHandler));

            // Check if the input list has reached the required length
            if (statueHandler.input.Count == statueHandler.answer.Length)
            {
                statueHandler.CheckAnswer();
                // Clear input for the next attempt
                statueHandler.input.Clear();
            }
        }
    }

    public int Press()
    {
        Debug.Log("Statue pressed: " + statueNumber);
        return statueNumber;
    }


}
