using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyPathOnTrigger : HandlePlayerTriggerEventBase
{
    public GameObject enemy;
    public EnemyTarget newTargetToChange;

    EnemyTarget previousTarget;
    EnemyAI enemyAI => enemy?.GetComponent<EnemyAI>();
    IEnemyState state => GetComponent<IEnemyState>();


    protected override void HandleTrigger()
    {
        if (enemyAI != null)
        {
            SetTarget();
        }
    }

    void CheckTarget()
    {
        if (state != null &&
            (state.CurrentState.GetType() == typeof(ChasePlayerState) || state.CurrentState.GetType() == typeof(InvestigateObjectState)))
        {
            SetTarget();   //ToDo, make possible extension method for this
        }
    }

    void SetTarget()
    {

        if (enemyAI.target.typeOfTarget != newTargetToChange.typeOfTarget)
        {
            enemyAI.SetCanPath();
            previousTarget = enemyAI.target;
            enemyAI.SetTarget(newTargetToChange);
        }
    }
}
