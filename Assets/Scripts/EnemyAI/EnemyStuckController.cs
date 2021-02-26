using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStuckController : MonoBehaviour
{
    EnemyAI enemy => GetComponent<EnemyAI>();
    IEnemyState state => GetComponent<IEnemyState>();
    Vector2 enemyLocation;
    public Transform resetSpawn;
    float Timer = 0f;
    float Delay = 10f;
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
            enemyLocation = transform.position;
        }
    }

    void ValidateEnemyPosition()
    {
        Debug.Log("Start Validation");
        if (Vector2.Distance(enemyLocation,transform.position) < 2.5f)
        {
            Debug.Log("Enemy Is Stuck!");
            FixEnemyStuckState();
        }
    }

    private void FixEnemyStuckState()
    {
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
