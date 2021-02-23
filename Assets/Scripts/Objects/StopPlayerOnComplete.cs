using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerOnComplete : MonoBehaviour
{
    public PlayerStateSO playerState;
    ICompleteGame Complete => GetComponent<ICompleteGame>();
    
    void Start()
    {
        if (Complete != null)
        {
            Complete.OnComplete += HandleComplete;
        }
    }

    void OnDestroy()
    {
        if (Complete != null)
        {
            Complete.OnComplete -= HandleComplete;
        }
    }

    private void HandleComplete()
    {
        if(playerState != null && playerState.IsPlayerReady())
        {
            playerState.isInteracting = true;
        }
    }
}
