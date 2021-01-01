using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDoorOnDialogueEnd : DisableOnDialogueEndBase
{
    public GameObject toggledDoor;
    IDoor door;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(toggledDoor != null)
        {
            door = toggledDoor.GetComponent<IDoor>();
        }
    }

    protected override void HandleEnd()
    {
        if (door != null)
        {
            if (door.IsOpen)
            {
                door.CloseDoor();
            }
            else
            {
                door.OpenDoor();
            }
        }
    }
}
