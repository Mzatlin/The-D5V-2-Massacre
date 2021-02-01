using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemySpeedOnChase : HandleEnemyStateChangeBase
{
    public float speedAmount = 25f;
    IEnemySpeed speed => GetComponent<IEnemySpeed>();
    IEnemyState state => GetComponent<IEnemyState>();
    bool isSpeedIncreased;

    protected override void HandleStateChange(EnemyStateBase obj)
    {
        if(state != null && 
            (state.CurrentState.GetType() == typeof(ChasePlayerState) || state.CurrentState.GetType() == typeof(InvestigateObjectState)))
        {
            if (!isSpeedIncreased)
            {
                IncreaseSpeed();
                isSpeedIncreased = true;
            }
        }
        else
        {
            if (isSpeedIncreased)
            {
                ResetSpeed();
                isSpeedIncreased = false;
            }
        }
    }

    void IncreaseSpeed()
    {
        if (speed != null)
        {
            speed.SetSpeed(speedAmount);
        }
    }

    void ResetSpeed()
    {
        if(speed != null)
        {
            speed.ResetSpeedToBase();
        }
    }

}
