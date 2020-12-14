using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGraphOnEnable : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(false);    
    }

    void OnEnable()
    {
        var graphToScan = AstarPath.active.data.gridGraph;
        AstarPath.active.Scan(graphToScan);
    }

     void OnDisable()
    {
        var graphToScan = AstarPath.active.data.gridGraph;
        AstarPath.active.Scan(graphToScan);
    }
}
