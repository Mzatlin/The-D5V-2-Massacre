using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyPathOnTrigger : MonoBehaviour
{
    public GameObject enemy;
    public EnemyTarget newTargetToChange;
    [SerializeField]
    LayerMask playerMask;

    EnemyTarget previousTarget;
    EnemyAI enemyAI => enemy?.GetComponent<EnemyAI>();
    ICompleteGame Complete => GetComponent<ICompleteGame>();
    IEnemyState state => GetComponent<IEnemyState>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((playerMask & 1 << collision.gameObject.layer) != 0)
        {
            if (enemyAI != null)
            {
                SetTarget();
            }
        }
    }

    void CheckTarget()
    {
        if (state != null &&
            (state.CurrentState.GetType() == typeof(ChasePlayerState) || state.CurrentState.GetType() == typeof(InvestigateObjectState)))
        {
            SetTarget();   //ToDo, make possible extension method for this
        }
    }

    void SetTarget()
    {

        if (enemyAI.target.typeOfTarget != newTargetToChange.typeOfTarget)
        {
            enemyAI.SetCanPath();
            previousTarget = enemyAI.target;
            enemyAI.SetTarget(newTargetToChange);
        }
    }
}
