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
            if (!hasDelayed && Vector3.Distance(transformEnemy.position, currentTarget.position) < 2.5f)
            {
                enemy.DelayAction(UnityEngine.Random.Range(3f,5f));
                enemy.SetCanPath();
                hasDelayed = true;
            }

            if (hasDelayed && !enemy.CheckDelay())
            {
                enemy.SetCanPath();
                hasDelayed = false;
                enemy.SetTarget(new EnemyTarget(enemy.PatrolTargets[0].gameObject, TargetType.None));
                return typeof(PatrolState);
            }

            if (playerCollider != null && playerCollider.enabled && Vector2.Distance(transformEnemy.position, enemy.PlayerTarget.position) < 3)
            {
                if (!enemy.GetCanPath())
                {
                    enemy.SetCanPath();
                }
                hasDelayed = false;
                return typeof(ChasePlayerState);
            }
        }

        return null;
    }

}
