using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStuckController : MonoBehaviour
{
    public Transform resetSpawn;
    public int stuckThreshold = 4;

    EnemyAI Enemy => GetComponent<EnemyAI>();
    IEnemyState State => GetComponent<IEnemyState>();

    Vector2 enemyLocation;
    float Timer = 0f;
    [SerializeField] int stuckCounter = 0;

    readonly float delay = 3.5f;
    readonly float moveDistance = 2f;

    void Start()
    {
        enemyLocation = transform.position;
    }

    //After a certain time in seconds, validate if the enemy is stuck somewhere 
    void Update()
    {
       if(Timer < delay)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            ValidateEnemyPosition();
            Timer = 0;
        }
    }

   //This will check and see if the enemy's location has changed much at all after a certain number of seconds
    void ValidateEnemyPosition()
    {
        //If the enemy hasn't moved a certain distance from the last spot, increment a stuck count
        if (Vector2.Distance(enemyLocation,transform.position) < moveDistance)
        {
            stuckCounter++;
            //When the stuck count has amet a certain threshold, then the enemy is definitely stuck and needs to be unstuck
            if (stuckCounter >= stuckThreshold)
            {
                stuckCounter = 0;
                FixEnemyStuckState();
            }
        }
        else
        {
            stuckCounter = 0;
            enemyLocation = transform.position;
        }
    }

    //Depending on the state of the enemy, different methods of fixing this will apply
    private void FixEnemyStuckState()
    {
        //Enemy is supposed to not be moving during a scripted stop point. Ignore
        if(Enemy.target.typeOfTarget == TargetType.ScriptedStopPoint)
        {
            return;
        }

        //Enemy state machine should revert to patrol, since the enemy is fixated on a target it can't reach
        if (State != null &&
             (State.CurrentState.GetType() == typeof(ChasePlayerState) || State.CurrentState.GetType() == typeof(InvestigateObjectState)))
        {
            Enemy.isStuck = true;
        }
        //This is a worst case, where the enemy is not fixated on a particular target, meaning it is REALLY stuck
        else if (State != null && (State.CurrentState.GetType() == typeof(PatrolState)))
        {
            ResetEnemyPosition();
        }
    }

    //Respawn the enemy 
    void ResetEnemyPosition()
    {
        if(resetSpawn != null)
        {
            transform.position = resetSpawn.position;
        }
    }
}
