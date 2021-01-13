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
    PlayerSprint sprintPlayer;

    public PatrolState(EnemyAI _enemy) : base(_enemy.gameObject)
    {
        enemy = _enemy;
    }

    public override void BeginState()
    {
        AkSoundEngine.SetState("EnemyState", "Patrol");
        currentPatrolPoint = enemy.PatrolTargets[index];
        enemy.SetTarget(currentPatrolPoint);
        size = enemy.PatrolTargets.Count - 1;
    }

    public override Type Tick()
    {
        if (!enemy.GetCanPath())
        {
            enemy.SetCanPath();
        }

        if (enemy.target.typeOfTarget == TargetType.Radio)
        {
            return typeof(InvestigateObjectState);
        }

        if(enemy.target.typeOfTarget == TargetType.ScriptedStopPoint)
        {
            return typeof(ScriptedStopState);
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

            if (enemy.PlayerGameObject.GetComponent<PlayerSprint>() == null)
            {
                Debug.Log("Not found");
            }

            if (enemy.PlayerTarget.gameObject.GetComponent<Collider2D>().enabled)
            {
                if (CheckLineOfSight())
                {
                    return typeof(ChasePlayerState);
                }

               if (Vector2.Distance(transformEnemy.position, enemy.PlayerTarget.position) < 5f && enemy.PlayerGameObject.GetComponent<PlayerSprint>().IsSprinting)
                {
                    return typeof(ChasePlayerState);
                }

                if (Vector2.Distance(transformEnemy.position, enemy.PlayerTarget.position) < 1f)
                {
                    return typeof(ChasePlayerState);
                }
            }



        }

        return null;
    }

    bool CheckLineOfSight()
    {
        Ray2D ray = new Ray2D(transformEnemy.position, gameObjectEnemy.GetComponent<Rigidbody2D>().velocity);
        Debug.DrawRay(ray.origin, ray.direction*6f, Color.red);
        bool hasSeenPlayer = false;
        RaycastHit2D[] results;
        results = Physics2D.RaycastAll(ray.origin, ray.direction, 6f); //check if raycast is hitting door or wall.
        foreach (RaycastHit2D hit in results)
        {
            LayerMask target = 1 << hit.collider.gameObject.layer;
            if ((target & enemy.obstacles) != 0)
            {
                return false;
            }
            if (hit.collider.transform == enemy.PlayerTarget)
            {
                hasSeenPlayer = true;
            }
        }

        if (hasSeenPlayer)
        {
            return true;
        }

        return false;
    }
}
