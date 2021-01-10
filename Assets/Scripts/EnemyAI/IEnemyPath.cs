using UnityEngine;

internal interface IEnemyPath
{
    void SetPathTarget(Transform nextTarget);
    bool CanPath { get; set; }
    float ObjectSpeed { get; set; }
}