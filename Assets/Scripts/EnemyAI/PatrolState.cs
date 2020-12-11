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
        AkSoundEngine.SetState("EnemyState", "Patrol");
        currentPatrolPoint = enemy.PatrolTargets[0];
        enemy.SetTarget(currentPatrolPoint);
        size = enemy.PatrolTargets.Count - 1;
    }

    public override Type Tick()
    {
        if (enemy.CurrentTarget == enemy.RadioTarget)
        {
            return typeof(InvestigateObjectState);
        }


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

            CheckLineOfSight();

            if (Vector2.Distance(transformEnemy.position, enemy.PlayerTarget.position) < 5 && enemy.PlayerTarget.gameObject.GetComponent<Collider2D>().enabled)
            {
                return typeof(ChasePlayerState);
            }

            

        }

        return null;
    }

    void CheckLineOfSight()
    {
        Ray2D ray = new Ray2D(transformEnemy.position, gameObjectEnemy.GetComponent<Rigidbody2D>().velocity);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        RaycastHit2D[] results;
        results = Physics2D.RaycastAll(ray.origin, ray.direction); //check if raycast is hitting door or wall.

    }
}
