using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyStateBase CurrentState { get; private set; }
    private Type nextState;
    private Dictionary<Type, EnemyStateBase> states;
    public event Action<EnemyStateBase> OnStateChanged;

    public void SetStates(Dictionary<Type,EnemyStateBase> _states)
    {
        states = _states;
    }

    void Start()
    {
        CurrentState = states.Values.First();
        CurrentState.BeginState();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentState != null)
        {
            nextState = CurrentState.Tick();
        }
        if(nextState != null && nextState != CurrentState?.GetType())
        {
            SwitchToNewState(nextState);
        }
    }

    void SwitchToNewState(Type nextState)
    {
        CurrentState = states[nextState];
        if(CurrentState != null)
        {
            CurrentState.BeginState();
            OnStateChanged?.Invoke(CurrentState);
        }
    }
}
