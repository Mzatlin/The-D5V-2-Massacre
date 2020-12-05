using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorOnInteract : HandleInteractionBase
{
    public KeyListSO keys;
    public string KeyName;
    INamePlate plate;

    protected override void Start()
    {
        base.Start();
        plate = GetComponent<INamePlate>();
    }

    protected override void HandleInteract()
    {
        if (keys.IsKeyCollected(KeyName))
        {
            gameObject.SetActive(false);
            if(plate != null)
            {
                plate.DisableNamePlate();
            }
        }
        base.HandleInteract();
    }
}
