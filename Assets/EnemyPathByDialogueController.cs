using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathByDialogueController : DisableOnDialogueEndBase
{
    public GameObject enemy;

    public EnemyTarget targetToChange;
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

    private void HandleActivation()
    {
        if(enemyAI != null)
        {
            enemyAI.SetCanPath();
            previousTarget = enemyAI.target;
            enemyAI.SetTarget(targetToChange);
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
