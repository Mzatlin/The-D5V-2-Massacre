using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChaseStateOnDialogueEnd : DisableOnDialogueEndBase
{
    public GameObject enemy;
    public Transform playerTarget;
    EnemyAI enemyAI;
   
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(enemy != null)
        {
            enemyAI = enemy.GetComponent<EnemyAI>();
        }
    }

    protected override void HandleEnd()
    {
        if (enemyAI != null)
        {
            enemyAI.SetTarget(playerTarget);
            enemyAI.SetTarget(new EnemyTarget(playerTarget.gameObject, TargetType.Player));
        }
    }
}
