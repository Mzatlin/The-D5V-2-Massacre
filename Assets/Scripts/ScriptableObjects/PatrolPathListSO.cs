using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Lists/PatrolPaths")]

public class PatrolPathListSO : ScriptableObject
{
    public int currentIndex;
    public List<GameObject> patrolPaths = new List<GameObject>();
}

