using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerOnInteractBase : MonoBehaviour
{
    public PlayerStateSO playerState;
    IActivateDialogue activate => GetComponent<IActivateDialogue>();
    IEndDialogue end => GetComponent<IEndDialogue>();

    protected virtual void Start()
    {
        if (end != null && activate != null)
        {
            activate.OnActivateDialogue += HandleActivation;
            end.OnEndDialogue += HandleEnd;
        }
    }

    protected virtual void OnDestroy()
    {
        if (end != null && activate != null)
        {
            activate.OnActivateDialogue -= HandleActivation;
            end.OnEndDialogue -= HandleEnd;
        }
    }

    protected virtual void HandleActivation()
    {
        playerState.isInteracting = true;
    }

    protected virtual void HandleEnd()
    {
        playerState.isInteracting = false;
    }
}
