using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessInteraction : MonoBehaviour, IInteractable, IInteractionStats
{
    [SerializeField]
    private bool isInteracting = false;
    [SerializeField]
    private bool isHovering = false;
    public bool IsInteracting => isInteracting;
    public bool IsHovering => isHovering;

    public event Action OnInteract = delegate { };

    public void StartInteraction()
    {
        if (!isInteracting && isHovering)
        {
            isInteracting = true;
            OnInteract();
            Debug.Log("Interacted!");
        }
    }

    public void StopInteraction()
    {
        if (isInteracting)
        {
            isInteracting = false;
        }
    }

    public void EnterInteractionRange()
    {
        if (!isInteracting)
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
