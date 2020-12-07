using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessInteraction : MonoBehaviour, IInteractable, IInteractionStats
{
    private bool isInteracting = false;
    private bool isHovering = false;
    private bool canInteract = true;
    public bool IsInteracting => isInteracting;
    public bool IsHovering => isHovering;

    public bool CanInteract { get => canInteract; set => canInteract = value; }

    public event Action OnInteract = delegate { };

    public void StartInteraction()
    {
        if (canInteract && !isInteracting && isHovering)
        {
            isInteracting = true;
            OnInteract();
        }
    }

    public void StopInteraction()
    {
        if (isInteracting)
        {
            isInteracting = false;
            isHovering = false;
        }
    }

    public void EnterInteractionRange()
    {
        if (canInteract && !isInteracting)
        {
            isHovering = true;
        }
        else
        {
            LeaveInteractionRange();
        }
    }

    public void LeaveInteractionRange()
    {
        if (isHovering)
        {
            isHovering = false;
        }

    }

}
