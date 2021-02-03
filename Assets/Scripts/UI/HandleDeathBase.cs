using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class HandleDeathBase : MonoBehaviour
{
    IDie die => GetComponent<IDie>();
    protected virtual void Start()
    {
        if (die != null)
        {
            die.OnDie += HandleDie;
        }
    }

    protected void OnDestroy()
    {
        if (die != null)
        {
            die.OnDie -= HandleDie;
        }
    }

    protected abstract void HandleDie();
}