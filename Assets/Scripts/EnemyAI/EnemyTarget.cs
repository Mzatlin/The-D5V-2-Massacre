using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemyTarget 
{
    public GameObject target;
    public Transform targetTransform;
    public TargetType typeOfTarget;

    public EnemyTarget(GameObject _target, Transform _targetTransform, TargetType _typeOfTarget)
    {
        target = _target;
        targetTransform = _targetTransform;
        typeOfTarget = _typeOfTarget;
    }
}

public enum TargetType
{
    Player,
    Radio,
    ScriptedStopPoint
}
