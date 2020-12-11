using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class OpenDoorOnInteract : HandleInteractionBase
{
    INamePlate plate;
    ICheckKey keyChecker;

    protected override void Start()
    {
        base.Start();
        plate = GetComponent<INamePlate>();
        keyChecker = GetComponent<ICheckKey>();
    }

    protected override void HandleInteract()
    {
        if (keyChecker.Keys.IsKeyCollected(keyChecker.KeyName))
        {
            gameObject.SetActive(false);
            if(plate != null)
            {
                plate.DisableNamePlate();
              //  Pathfinding.AstarPathEditor.MenuScan();
            }
        }
        base.HandleInteract();
    }
}
