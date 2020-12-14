using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueOnTriggerEnter : StartDialogueBase
{
    public PlayerStateSO playerState;
    public LayerMask playerMask;
    public float delay = 0f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if ((playerMask & 1 << collider.gameObject.layer) != 0)
        {
            ActivateDialogue();
        }
    }

    protected override void ActivateDialogue()
    {
        playerState.isInteracting = true;
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
        base.ActivateDialogue();
    }

}
