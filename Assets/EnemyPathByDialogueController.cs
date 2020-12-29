using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathByDialogueController : DisableOnDialogueEndBase
{
    public GameObject enemy;
    public GameObject player;
    public GameObject scriptedSpot;
    EnemyAI AiEnemy => enemy?.GetComponent<EnemyAI>();
    IActivateDialogue ActivateDialogue => GetComponent<IActivateDialogue>();
    // Start is called before the first frame update
    protected override void Start()
    {
        if(enemy == null || AiEnemy == null)
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
        if(AiEnemy != null)
        {
            AiEnemy.SetCanPath();
            AiEnemy.SetTarget(new EnemyTarget(scriptedSpot.gameObject, TargetType.ScriptedStopPoint));
        }
        else
        {
            Debug.Log("No AI assigned");
        }
    }

    protected override void HandleEnd()
    {
        if (AiEnemy != null)
        {
            AiEnemy.SetCanPath();
            AiEnemy.SetTarget(new EnemyTarget(player.gameObject, TargetType.Player));
        }
        else
        {
            Debug.Log("No AI assigned");
        }
    }

}
