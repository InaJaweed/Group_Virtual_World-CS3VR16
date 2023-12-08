using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    public Image crosshair;
    public Color highlightColor = Color.red;

    private Color originalColor;

    void Start()
    {
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

                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("Interact key pressed");
                        interactObj.Interact();
                    }
                }
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
        crosshair.color = highlightColor;
    }

    void ResetCrosshair()
    {
        crosshair.color = originalColor;
    }
}
