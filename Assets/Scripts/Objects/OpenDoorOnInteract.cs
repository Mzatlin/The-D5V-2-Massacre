using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class OpenDoorOnInteract : HandleInteractionBase, IDoor
{
    INamePlate plate;
    ICheckKey keyChecker;
    public Sprite spriteSwap;
    SpriteRenderer render;
    public Collider2D[] pathBlockers;
    [SerializeField]
    bool isOpen = false;
    public bool IsOpen => isOpen;

    protected override void Start()
    {
        base.Start();
        plate = GetComponent<INamePlate>();
        keyChecker = GetComponent<ICheckKey>();
        pathBlockers = GetComponentsInChildren<Collider2D>();
        render = GetComponent<SpriteRenderer>();
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
        if(pathBlockers != null)
        {
            foreach(Collider2D path in pathBlockers)
            {
                path.enabled = false;
            }
        }
       

        if(spriteSwap != null)
        {
            render.sprite = spriteSwap;
        }

        if (plate != null)
        {
            plate.DisableNamePlate();
            var graphToScan = AstarPath.active.data.gridGraph;
            AstarPath.active.Scan(graphToScan);
        }
    }
}
