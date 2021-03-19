using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GraphScanExtensionMethods 
{
    public static void ReScanPathFindingGraph()
    {
        var graphToScan = AstarPath.active.data.gridGraph;
        AstarPath.active.Scan(graphToScan);
    }
}
