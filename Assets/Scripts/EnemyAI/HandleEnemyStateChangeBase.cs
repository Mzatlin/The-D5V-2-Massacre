using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandleEnemyStateChangeBase : MonoBehaviour
{
    IEnemyState state => GetComponent<IEnemyState>();
    protected virtual void Start()
    {
        state.OnStateChanged += HandleStateChange;
    }

    protected virtual  void OnDestroy()
    {
        if (state != null)
        {
            state.OnStateChanged -= HandleStateChange;
        }
    }

    protected abstract void HandleStateChange(EnemyStateBase obj);
}
