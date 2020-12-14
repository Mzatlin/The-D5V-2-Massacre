using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueEndSetEnemyActive : DisableOnDialogueEndBase
{
    public GameObject Enemy;
    public Transform scriptedTarget;
    EnemyAI enemyAI;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        enemyAI = Enemy.GetComponent<EnemyAI>();
    }

    protected override void HandleEnd()
    {
        if(Enemy != null)
        {
            Enemy.SetActive(true);
            if(enemyAI != null)
            {
                enemyAI.SetTarget(scriptedTarget);
            }
        }
    }
}
