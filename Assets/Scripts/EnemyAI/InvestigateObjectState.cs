using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InvestigateObjectState : EnemyStateBase
{
    EnemyAI enemy;
    Transform currentTarget;
    Collider2D playerCollider;
    bool hasDelayed = false;

    public InvestigateObjectState(EnemyAI _enemy) : base(_enemy.gameObject)
    {
        enemy = _enemy;
    }

    public override void BeginState()
    {
        currentTarget = enemy.CurrentTarget;
        playerCollider = enemy.PlayerTarget.gameObject.GetComponent<Collider2D>();
    }

    public override Type Tick()
    {
        if (currentTarget != null)
        {

            if (!hasDelayed && Vector3.Distance(transformEnemy.position, currentTarget.position) < 1f)
            {
                enemy.DelayAction(UnityEngine.Random.Range(4f,6f));
                hasDelayed = true;
            }

            if (hasDelayed && !enemy.CheckDelay())
            {
                hasDelayed = false;
                return typeof(PatrolState);
            }

            if (playerCollider != null && playerCollider.enabled && Vector2.Distance(transformEnemy.position, enemy.PlayerTarget.position) < 5)
            {
                return typeof(ChasePlayerState);
            }
        }

        return null;
    }

}
