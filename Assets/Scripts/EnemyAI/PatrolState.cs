using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatrolState : EnemyStateBase
{
    EnemyAI enemy;
    int index = 0;
    int size;
    List<Transform> locations = new List<Transform>();
    Transform currentPatrolPoint;
    public PatrolState(EnemyAI _enemy) : base(_enemy.gameObject)
    {
        enemy = _enemy;
    }

    public override void BeginState()
    {
        currentPatrolPoint = enemy.PatrolTargets[0];
        enemy.SetTarget(currentPatrolPoint);
        size = enemy.PatrolTargets.Count - 1;

    }

    public override Type Tick()
    {

        if (currentPatrolPoint != null)
        {
            if (Vector2.Distance(transformEnemy.position, currentPatrolPoint.position) < 1)
            {
                if (index >= size)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
                currentPatrolPoint = enemy.PatrolTargets[index];
                enemy.SetTarget(currentPatrolPoint);
            }


            if (Vector2.Distance(transformEnemy.position, enemy.PlayerTarget.position) < 5 && enemy.PlayerTarget.gameObject.GetComponent<Collider2D>().enabled)
            {
                return typeof(ChasePlayerState);
            }


        }

        return null;
    }
}
