using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffColliderOnTrigger : HandlePlayerTriggerEventBase
{
    public GameObject objectCollider;
    Collider2D colliderToVanish;

    protected override void Start()
    {
        base.Start();
        if (objectCollider != null)
        {
            colliderToVanish = objectCollider.GetComponent<Collider2D>();
            if(colliderToVanish != null)
                  colliderToVanish.enabled = true;
        }
    }

    protected override void HandleTrigger()
    {
        if (colliderToVanish != null)
        {
            colliderToVanish.enabled = false;
        }
    }
}
