using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InvestigateObjectState : EnemyStateBase
{
    EnemyAI enemy;

    public InvestigateObjectState(EnemyAI _enemy) : base(_enemy.gameObject)
    {
        enemy = _enemy;
    }

    public override void BeginState()
    {
        throw new NotImplementedException();
    }

    public override Type Tick()
    {
        throw new NotImplementedException();
    }
}
