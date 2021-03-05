using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectActiveOnTrigger : HandlePlayerTriggerEventBase
{
    public GameObject objectToVanish;


    protected override void Start()
    {
        base.Start();
        if (objectToVanish != null)
        {
            objectToVanish.SetActive(false);
        }
    }

    protected override void HandleTrigger()
    {
        if (objectToVanish != null)
        {
            objectToVanish.SetActive(true);
            ScanGraph();
        }
    }

    void ScanGraph() //Todo: Extension Method 
    {
        var graphToScan = AstarPath.active.data.gridGraph;
        AstarPath.active.Scan(graphToScan);
    }
}
