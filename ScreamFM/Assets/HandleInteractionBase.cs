using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInteractionBase : MonoBehaviour
{
    private IInteractable interact;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        interact = GetComponent<IInteractable>();
        if (interact != null)
        {
            interact.OnInteract += HandleInteract;
        }
    }

    private void OnDestroy()
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
