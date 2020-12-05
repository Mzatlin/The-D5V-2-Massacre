using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKeyOnInteract : MonoBehaviour
{
    [SerializeField]
    private string keyName;
    public KeyListSO keys;
    IInteractable interact;
    IInteractionStats stats;

    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<IInteractable>();
        if(interact != null)
        {
            interact.OnInteract += HandleInteract;
        }
        stats = GetComponent<IInteractionStats>();
    }

    private void OnDestroy()
    {
        if(interact != null)
        {
            interact.OnInteract -= HandleInteract;
        }
    }

    void HandleInteract()
    {
        if (!keys.IsKeyCollected(keyName))
        {
            keys.keyStatuses[keyName] = true;
            stats.CanInteract = false;
        }

        interact.StopInteraction();
    }
}
