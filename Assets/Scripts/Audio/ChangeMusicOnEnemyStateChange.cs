using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicOnEnemyStateChange : HandleEnemyStateChangeBase
{
    IEnemyState state => GetComponent<IEnemyState>();


    protected override void HandleStateChange(EnemyStateBase obj)
    {
        if(state != null)
        {
            ChangeMusic(state.CurrentState.GetType());
        }
    }

    void ChangeMusic(Type state)
    {
        if(state == typeof(PatrolState))
        {
            AkSoundEngine.SetState("EnemyState", "Patrol");
        }
        else if(state == typeof(ChasePlayerState))
        {
            AkSoundEngine.SetState("EnemyState", "Chase");
        }
        else if (state == typeof(InvestigateObjectState))
        {
            AkSoundEngine.SetState("EnemyState", "Investigate");
        }
    }
}

