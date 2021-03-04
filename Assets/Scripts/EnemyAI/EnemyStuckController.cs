using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStuckController : MonoBehaviour
{
    EnemyAI enemy => GetComponent<EnemyAI>();
    IEnemyState state => GetComponent<IEnemyState>();
    Vector2 enemyLocation;
    public Transform resetSpawn;
    public int stuckThreshold = 3;
    float Timer = 0f;
    int stuckCounter = 0;
    float Delay = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        enemyLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(Timer < Delay)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            ValidateEnemyPosition();
            Timer = 0;
        }
    }

    void ValidateEnemyPosition()
    {
        Debug.Log("Start Validation");
        if (Vector2.Distance(enemyLocation,transform.position) < 2.5f)
        {
            stuckCounter++;
            if (stuckCounter >= stuckThreshold)
            {
                Debug.Log("Enemy Is Stuck!");
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

    private void FixEnemyStuckState()
    {
        if(enemy.target.typeOfTarget == TargetType.ScriptedStopPoint)
        {
            return;
        }

        if (state != null &&
             (state.CurrentState.GetType() == typeof(ChasePlayerState) || state.CurrentState.GetType() == typeof(InvestigateObjectState)))
        {
            enemy.isStuck = true;
        }
        else if (state != null && (state.CurrentState.GetType() == typeof(PatrolState)))
        {
            ResetEnemyPosition();
        }
    }

    void ResetEnemyPosition()
    {
        if(resetSpawn != null)
        {
            transform.position = resetSpawn.position;
        }
    }
}
