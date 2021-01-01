using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorController : MonoBehaviour, IDoor
{
    // Start is called before the first frame update
    INamePlate Plate =>  GetComponent<INamePlate>();
    public Sprite spriteSwap;
    Sprite originalSprite;
    SpriteRenderer render;
    public Collider2D[] pathBlockers;
    [SerializeField]
    bool isOpen = false;
    public bool IsOpen => isOpen;

    void Start()
    {
        pathBlockers = GetComponentsInChildren<Collider2D>();
        render = GetComponent<SpriteRenderer>();
        if(render != null)
        {
            originalSprite = render.sprite;
        }
        if (IsOpen)
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        if (pathBlockers != null)
        {
            foreach (Collider2D path in pathBlockers)
            {
                path.enabled = false;
            }
        }

        if (spriteSwap != null)
        {
            render.sprite = spriteSwap;
        }

        if (Plate != null)
        {
            Plate.DisableNamePlate();
        }
        ScanGraph();

        isOpen = true;
    }

    public void CloseDoor()
    {
        if (pathBlockers != null)
        {
            foreach (Collider2D path in pathBlockers)
            {
                path.enabled = true;
            }
        }

        if (originalSprite != null)
        {
            render.sprite = originalSprite;
        }
        ScanGraph();

        isOpen = false;
    }

    void ScanGraph()
    {
        var graphToScan = AstarPath.active.data.gridGraph;
        AstarPath.active.Scan(graphToScan);
    }
}
