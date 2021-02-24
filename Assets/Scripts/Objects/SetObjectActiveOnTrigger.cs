using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectActiveOnTrigger : MonoBehaviour
{
    public GameObject objectToVanish;
    [SerializeField]
    LayerMask playerMask;

    private void Awake()
    {
        if(objectToVanish != null)
        {
            objectToVanish.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((playerMask & 1 << collision.gameObject.layer) != 0)
        {
            if (objectToVanish != null)
            {
                objectToVanish.SetActive(true);
                ScanGraph();
            }
        }
    }
    void ScanGraph() //Todo: Extension Method 
    {
        var graphToScan = AstarPath.active.data.gridGraph;
        AstarPath.active.Scan(graphToScan);
    }
}
