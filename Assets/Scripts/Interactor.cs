using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    public Image crosshair;
    public Color highlightColor = Color.red; // Set your desired highlight color

    private Color originalColor;//hello jaweed

    void Start()
    {
        // Store the original color for resetting
        originalColor = crosshair.color;
    }

    void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);

        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            GameObject hitObject = hitInfo.collider.gameObject;

            if (hitObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                HighlightCrosshair();
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj) && Input.GetKeyDown(KeyCode.E)) interactObj.Interact();
            }
            else
            {
                ResetCrosshair();  
            }
        }
        else
        {
            ResetCrosshair();
        }
    }

    void HighlightCrosshair()
    {
        crosshair.color = Color.red;
        //crosshair.color = highlightColor;
    }

    void ResetCrosshair()
    {
        crosshair.color = Color.white;
        //crosshair.color = originalColor;
    }
}
