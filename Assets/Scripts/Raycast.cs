using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [Header("Raycast Features")]
    [SerializeField] private float raylength = 5;
    private Camera mainCamera;

    private NoteController noteController;

    [Header("Crosshair")]
    [SerializeField] private Image crosshair;

    [Header("Input Key")]
    [SerializeField] private KeyCode interactKey;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Physics.Raycast(mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, raylength))
        {
            var readableItem = hit.collider.GetComponent<NoteController>();
            if (readableItem != null)
            {
                noteController = readableItem;
                HighlightCrosshair(true);
            }
            else
            {
                ClearNote();
            }
        }
        else
        {
            ClearNote();
        }
        if (noteController != null)
        {
            if (Input.GetKeyDown(interactKey))
            {
                noteController.ShowNote();
            }
        }
    }

    void ClearNote()
    {
        if (noteController != null)
        {
            HighlightCrosshair(false);
            noteController = null;
        }
    }

    void HighlightCrosshair(bool on)
    {
        if (on)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
        }
    }

}
