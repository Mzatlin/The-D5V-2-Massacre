using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartDialogueBase : MonoBehaviour, IActivateDialogue
{
    public event Action OnActivateDialogue = delegate { };

    protected virtual void ActivateDialogue()
    {
        OnActivateDialogue();
    }
}
