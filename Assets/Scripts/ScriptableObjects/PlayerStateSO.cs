using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerState")]
public class PlayerStateSO : ScriptableObject
{
    public bool isDead = false;
    public bool isInteracting = false;
    public bool isPaused = false;

    public bool IsPlayerReady()
    {
        if(isDead || isInteracting || isPaused)
        {
            return false;
        }

        return true;
    }
}
