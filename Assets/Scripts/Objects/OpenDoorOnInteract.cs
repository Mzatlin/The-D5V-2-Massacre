using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class OpenDoorOnInteract : HandleInteractionBase, IDoor
{
    INamePlate plate;
    ICheckKey keyChecker;
    public Sprite spriteSwap;
    bool isOpen = false;
    public bool IsOpen => isOpen;

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
            OpenDoor();
        }
        base.HandleInteract();
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
        if (plate != null)
        {
            plate.DisableNamePlate();
            var graphToScan = AstarPath.active.data.gridGraph;
            AstarPath.active.Scan(graphToScan);
        }
    }
}
