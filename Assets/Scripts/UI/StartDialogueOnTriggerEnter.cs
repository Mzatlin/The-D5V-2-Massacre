using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueOnTriggerEnter : MonoBehaviour, IActivateDialogue
{
    public event Action OnActivateDialogue = delegate { };
    public LayerMask playerMask;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((playerMask & 1 << collider.gameObject.layer) != 0)
        {
            OnActivateDialogue();
        }
    }

}
