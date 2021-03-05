using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectPositionOnTrigger : HandlePlayerTriggerEventBase
{
    public GameObject objectToChange;
    public Transform newLocation;
    protected override void HandleTrigger()
    {
        if(newLocation != null && objectToChange != null)
        {
            objectToChange.transform.position = newLocation.transform.position;
        }
    }
}


