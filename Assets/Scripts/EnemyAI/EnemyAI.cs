using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    IEnemyPath enemyPath => GetComponent<IEnemyPath>();
    IEnemyDirection enemyDirection => GetComponent<IEnemyDirection>();
    [SerializeField]
    GameObject test;
    [SerializeField]
    private Transform playerTarget;
    [SerializeField]
    private List<Transform> patrolTargets = new List<Transform>();
    //  public bool CanPath { get => enemyPath.CanPath; set => CanPath = value; }
    public Transform PlayerTarget => playerTarget;
    public Transform RadioTarget { get; set; }
    public Transform CurrentTarget { get; private set; }
    public List<Transform> PatrolTargets => patrolTargets;
    public EnemyStateMachine StateMachine => GetComponent<EnemyStateMachine>();

    // Start is called before the first frame update
    void Awake()
    {
        InitializeStateMachine();
        SetPatrolPath(test);
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

    public Vector2 GetDirection()
    {
        return enemyDirection.Direction;
    }

    public void DelayAction(float delay)
    {
        StateMachine.DelayTransition(delay);
    }

    public bool CheckDelay()
    {
        return StateMachine.IsDelayed;
    }

    public void SetCanPath()
    {
        enemyPath.CanPath = !enemyPath.CanPath;
    }

    public void SetPatrolPath(GameObject pathChildren)
    {
        Transform[] paths = pathChildren.GetComponentsInChildren<Transform>();
        patrolTargets.Clear();
        foreach (Transform path in paths)
        {
            patrolTargets.Add(path);
        }
        patrolTargets.RemoveAt(0);
    }


}