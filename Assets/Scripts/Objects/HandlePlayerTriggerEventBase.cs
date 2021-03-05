using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandlePlayerTriggerEventBase : MonoBehaviour
{
    IPlayerTrigger Trigger => GetComponent<IPlayerTrigger>();
   
    protected virtual void Start()
    {
        if (Trigger != null)
        {
            Trigger.OnPlayerTrigger += HandleTrigger;
        }
    }


    protected void OnDestroy()
    {
        if (Trigger != null)
        {
            Trigger.OnPlayerTrigger -= HandleTrigger;
        }
    }

    protected abstract void HandleTrigger();
}
