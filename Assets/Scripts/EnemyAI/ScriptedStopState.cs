using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedStopState : EnemyStateBase
{
    EnemyAI enemy;
    public ScriptedStopState(EnemyAI _enemy) : base(_enemy.gameObject)
    {
        enemy = _enemy;
    }
    public override void BeginState()
    {
        AkSoundEngine.SetState("EnemyState", "Chase");
    }

    public override Type Tick()
    {
        if(enemy.target.typeOfTarget != TargetType.ScriptedStopPoint)
        {
            return typeof(ChasePlayerState);
        }

        if(Vector2.Distance(transformEnemy.position, enemy.PlayerTarget.position) < 3f)
        {
            enemy.SetCanPath();
        }



        return null;
    }

}
