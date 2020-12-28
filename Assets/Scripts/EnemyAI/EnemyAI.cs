using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    IEnemyPath enemyPath => GetComponent<IEnemyPath>();
    IEnemyDirection enemyDirection => GetComponent<IEnemyDirection>();
    [SerializeField]
    private Transform playerTarget;
    [SerializeField]
    private GameObject playerGameObject;
    [SerializeField]
    private List<Transform> patrolTargets = new List<Transform>();
    //  public bool CanPath { get => enemyPath.CanPath; set => CanPath = value; }
    public Transform PlayerTarget => playerTarget;
    public GameObject PlayerGameObject => playerGameObject;
    public Transform CurrentTarget { get; private set; }
    public List<Transform> PatrolTargets => patrolTargets;
    public EnemyStateMachine StateMachine => GetComponent<EnemyStateMachine>();
    public PatrolPathListSO paths;
    public LayerMask obstacles;
    public EnemyTarget target;

    // Start is called before the first frame update
    void Awake()
    {
        SetPatrolPath(paths?.patrolPaths[0]);
        InitializeStateMachine();
        target = new EnemyTarget(PlayerGameObject, TargetType.Player);
    }

    void InitializeStateMachine()
    {
        var states = new Dictionary<Type, EnemyStateBase>()
        {
            {typeof(PatrolState),new PatrolState(this) },
            {typeof(ChasePlayerState),new ChasePlayerState(this) },
            {typeof(InvestigateObjectState),new InvestigateObjectState(this) },
             {typeof(ScriptedStopState),new ScriptedStopState(this) },
        };

        StateMachine.SetStates(states);
    }

    public void SetTarget(Transform target)
    {
        CurrentTarget = target;
        enemyPath?.SetPathTarget(target);
    }

    public void SetTarget(EnemyTarget _target)
    {
        target = _target;
        CurrentTarget = _target.targetTransform;
        enemyPath?.SetPathTarget(_target.targetTransform);
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

    public bool GetCanPath()
    {
        return enemyPath.CanPath;
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

    public PlayerSprint GetPlayerSprint()
    {
        return playerGameObject.GetComponent<PlayerSprint>();
    }


}