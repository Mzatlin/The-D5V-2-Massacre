using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorOnRadioComplete : HandlePlayerTriggerEventBase
{
    public List<GameObject> doors = new List<GameObject>();

    protected override void HandleTrigger()
    {
        CloseDoor();
    }

    void CloseDoor()
    {
        foreach (GameObject door in doors)
        {
            if (door != null)
            {
                var doorToggle = door.GetComponent<IDoor>();
                if (doorToggle != null)
                {
                    doorToggle.CloseDoor();
                }
            }
        }
    }
}
