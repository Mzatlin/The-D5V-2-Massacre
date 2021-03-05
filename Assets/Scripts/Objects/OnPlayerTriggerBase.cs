using System;
using UnityEngine;

public class OnPlayerTriggerBase : MonoBehaviour, IPlayerTrigger
{
    public event Action OnPlayerTrigger = delegate { };
    public LayerMask playerMask;
    public RadioCompletionListSO radio;


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (((playerMask & 1 << collision.gameObject.layer) != 0) && radio != false && radio.HasWon())
        {
            OnPlayerTrigger();
        }
    }
}
