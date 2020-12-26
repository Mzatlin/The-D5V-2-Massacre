using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemyTarget 
{
    public GameObject target;
    public Transform targetTransform;
    public TargetType typeOfTarget;

    public EnemyTarget(GameObject _target, TargetType _typeOfTarget)
    {
        target = _target;
        targetTransform = _target.transform;
        typeOfTarget = _typeOfTarget;
    }
}

public enum TargetType
{
    Player,
    Radio,
    ScriptedStopPoint
}
