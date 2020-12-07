using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInteractionBase : MonoBehaviour
{
    private IInteractable interact => GetComponent<IInteractable>();
    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (interact != null)
        {
            interact.OnInteract += HandleInteract;
        }
    }

    void OnDestroy()
    {
        if (interact != null)
        {
            interact.OnInteract -= HandleInteract;
        }
    }

    protected virtual void HandleInteract()
    {
        interact.StopInteraction();
    }
}
