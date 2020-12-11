using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePatrolPathOnRadioComplete : MonoBehaviour
{
    public RadioCompletionListSO radioCompletion;
    public PatrolPathListSO patrol;
    EnemyAI enemy => GetComponent<EnemyAI>();
    // Start is called before the first frame update
    void Start()
    {
        if (radioCompletion != null)
        {
            radioCompletion.OnRadioComplete += HandleRadioComplete;
        }
        if (enemy != null && patrol != null)
        {
            enemy.SetPatrolPath(patrol.patrolPaths[0]);
        }

    }

    void OnDestroy()
    {
        if (radioCompletion != null)
        {
            radioCompletion.OnRadioComplete -= HandleRadioComplete;
        }
       
    }

    void HandleRadioComplete(Transform obj)
    {
      //  if(enemy != null && radioCompletion != null)
     //   {
            Debug.Log("Setting Path for "+radioCompletion.completeCount);
            enemy.SetPatrolPath(patrol.patrolPaths[radioCompletion.completeCount]);
      //  }
    }

}
