using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class OpenDoorOnInteract : HandleInteractionBase
{

    ICheckKey KeyChecker => GetComponent<ICheckKey>();
    IDoor Door => GetComponent<IDoor>();

    protected override void Start()
    {
        base.Start();     
    }

    protected override void HandleInteract()
    {
        if (KeyChecker != null && KeyChecker.Keys.IsKeyCollected(KeyChecker.KeyName))
        {
            if(Door != null)
            {
                Door.OpenDoor();
            }
        }
        base.HandleInteract();
    }


}
