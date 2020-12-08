using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    IEnemyPath enemyPath => GetComponent<IEnemyPath>();
   

    [SerializeField]
    private Transform playerTarget;
    [SerializeField]
    private List<Transform> patrolTargets = new List<Transform>();

    public Transform PlayerTarget => playerTarget;
    public Transform CurrentTarget { get; private set; }
    public List<Transform> PatrolTargets => patrolTargets;
    public EnemyStateMachine StateMachine => GetComponent<EnemyStateMachine>();

    // Start is called before the first frame update
    void Awake()
    {
        InitializeStateMachine();
    }

    void InitializeStateMachine()
    {
        var states = new Dictionary<Type, EnemyStateBase>()
        {
            {typeof(PatrolState),new PatrolState(this) },
            {typeof(ChasePlayerState),new ChasePlayerState(this) },
            {typeof(InvestigateObjectState),new InvestigateObjectState(this) },
        };

        StateMachine.SetStates(states);
    }

    public void SetTarget(Transform target)
    {
        CurrentTarget = target;
        enemyPath?.SetPathTarget(target);
    }

    public void DelayAction(float delay)
    {
        StateMachine.DelayTransition(delay);
    }

    public bool CheckDelay()
    {
        return StateMachine.IsDelayed;
    }


}