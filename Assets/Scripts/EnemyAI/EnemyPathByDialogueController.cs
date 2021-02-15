using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathByDialogueController : DisableOnDialogueEndBase
{
    public GameObject enemy;

    public EnemyTarget newTargetToChange;
    EnemyTarget previousTarget;

    EnemyAI enemyAI => enemy?.GetComponent<EnemyAI>();
    IActivateDialogue ActivateDialogue => GetComponent<IActivateDialogue>();
    // Start is called before the first frame update
    protected override void Start()
    {
        if(enemy == null || enemyAI == null)
        {
            Debug.Log("No gameobject or EnemyAI assigned to Path Dialogue Controller");
        }
        ActivateDialogue.OnActivateDialogue += HandleActivation;
        base.Start();
    }

    private void OnDestroy()
    {
        if(ActivateDialogue != null)
        {
            ActivateDialogue.OnActivateDialogue -= HandleActivation;
        }
    }

    void SetTarget()
    {

        if(enemyAI.target.typeOfTarget != newTargetToChange.typeOfTarget)
        {
            enemyAI.SetCanPath();
            previousTarget = enemyAI.target;
            enemyAI.SetTarget(newTargetToChange);
        }
    }

    private void HandleActivation()
    {
        if(enemyAI != null)
        {
            SetTarget();
        }
        else
        {
            Debug.Log("No AI assigned");
        }
    }

    protected override void HandleEnd()
    {
        if (enemyAI != null)
        {
            enemyAI.SetCanPath();
            enemyAI.SetTarget(previousTarget);
        }
        else
        {
            Debug.Log("No AI assigned");
        }
    }

}
