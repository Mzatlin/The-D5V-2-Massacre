using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemySpeedOnChase : MonoBehaviour
{
    public float speedAmount = 25f;
    EnemyStateMachine stateMachine => GetComponent<EnemyStateMachine>();
    IEnemySpeed speed => GetComponent<IEnemySpeed>();
    bool isSpeedIncreased;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine.OnStateChanged += HandleStateChange;
    }

    private void OnDestroy()
    {
        if(stateMachine != null)
        {
            stateMachine.OnStateChanged -= HandleStateChange;
        }
    }

    private void HandleStateChange(EnemyStateBase obj)
    {
        if(stateMachine != null && 
            (stateMachine.CurrentState.GetType() == typeof(ChasePlayerState) || stateMachine.CurrentState.GetType() == typeof(InvestigateObjectState)))
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
