using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedStopState : EnemyStateBase
{
    EnemyAI enemy;
    EnemyTarget currentTarget;
    public ScriptedStopState(EnemyAI _enemy) : base(_enemy.gameObject)
    {
        enemy = _enemy;
    }
    public override void BeginState()
    {
       currentTarget = enemy.GetPreviousEnemyTarget();

        if (currentTarget.typeOfTarget == TargetType.Player)
        {
            AkSoundEngine.SetState("EnemyState", "Chase");
        }
    }

    public override Type Tick()
    {
        if(enemy.target.typeOfTarget != TargetType.ScriptedStopPoint)
        {
            return SetType();
        }

        if(Vector2.Distance(transformEnemy.position, enemy.PlayerTarget.position) < 2f)
        {
            enemy.SetCanPath();
        }



        return null;
    }

    Type SetType()
    {
        if (currentTarget.typeOfTarget == TargetType.Player)
        {
            return typeof(ChasePlayerState);
        }
        if(currentTarget.typeOfTarget == TargetType.Radio)
        {
            return typeof(InvestigateObjectState);
        }
        if(currentTarget.typeOfTarget == TargetType.None)
        {
            enemy.SetTarget(new EnemyTarget(enemy.PatrolTargets[0].gameObject, TargetType.None));
            return typeof(PatrolState);
        }
        else
        {
            return null;
        }

    }

}
