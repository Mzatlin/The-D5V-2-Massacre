using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRadioOnCompletion : MonoBehaviour
{
    EnemyAI enemy => GetComponent<EnemyAI>();
    EnemyStateMachine StateMachine => GetComponent<EnemyStateMachine>();
    public RadioCompletionListSO completion;
    // Start is called before the first frame update
    void Start()
    {
        if(completion != null)
        {
            completion.OnRadioComplete += HandleRadioCompletion;
        }
    }

    void OnDestroy()
    {
        if (completion != null)
        {
            completion.OnRadioComplete -= HandleRadioCompletion;
        }
    }

    void HandleRadioCompletion(Transform radioTransform)
    {
        if (StateMachine != null
            && (StateMachine.CurrentState.GetType() == typeof(PatrolState) || StateMachine.CurrentState.GetType() == typeof(InvestigateObjectState)))
        {
            enemy.RadioTarget = radioTransform;
            enemy.SetTarget(enemy.RadioTarget);
        }
    }

}
