using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKeyOnInteract : HandleInteractionBase
{
    [SerializeField]
    private string keyName;
    public KeyListSO keys;
    IInteractionStats stats;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stats = GetComponent<IInteractionStats>();
    }

    protected override void HandleInteract()
    {
        if (!keys.IsKeyCollected(keyName))
        {
            keys.keyStatuses[keyName] = true;
            stats.CanInteract = false;
        }
    }
}
