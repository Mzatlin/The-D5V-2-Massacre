using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerDuringDialogue : MonoBehaviour
{
    public PlayerStateSO playerState;
    IActivateDialogue activate => GetComponent<IActivateDialogue>();
    IEndDialogue end => GetComponent<IEndDialogue>();

    void Start()
    {
        if(end != null && activate != null)
        {
            activate.OnActivateDialogue += HandleActivation;
            end.OnEndDialogue += HandleEnd;
        }    
    }

    void OnDestroy()
    {
        if (end != null && activate != null)
        {
            activate.OnActivateDialogue -= HandleActivation;
            end.OnEndDialogue -= HandleEnd;
        }
    }

    private void HandleActivation()
    {
        playerState.isInteracting = true;
    }

    private void HandleEnd()
    {
        playerState.isInteracting = false;
    }



}
