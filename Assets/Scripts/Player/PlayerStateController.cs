using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour, IPlayerState
{
    [SerializeField]
    private PlayerStateSO playerState;

    public PlayerStateSO PlayerState => playerState;

    void Awake()
    {
        playerState.isDead = false;
        playerState.isInteracting = false;
        playerState.isPaused = false;
    }
}
