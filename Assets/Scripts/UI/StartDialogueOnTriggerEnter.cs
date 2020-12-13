using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueOnTriggerEnter : StartDialogueBase
{
    public LayerMask playerMask;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((playerMask & 1 << collider.gameObject.layer) != 0)
        {
            ActivateDialogue();
        }
    }

    protected override void ActivateDialogue()
    {
        base.ActivateDialogue();
    }

}
