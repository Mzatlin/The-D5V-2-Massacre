using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueOnInteract : StartDialogueBase
{
    IInteractable interact => GetComponent<IInteractable>();
    // Start is called before the first frame update
    void Start()
    {
        if(interact != null)
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

    private void HandleInteract()
    {
        ActivateDialogue();
    }

    protected override void ActivateDialogue()
    {
        base.ActivateDialogue();
    }
}
