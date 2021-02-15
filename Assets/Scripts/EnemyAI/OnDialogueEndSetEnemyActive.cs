using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueEndSetEnemyActive : DisableOnDialogueEndBase//,ISetTarget 
{
    public GameObject Enemy;
    public EnemyTarget scriptedTarget;
    EnemyAI enemyAI;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        enemyAI = Enemy.GetComponent<EnemyAI>();
    }

    void SetTarget()
    {
        enemyAI.SetTarget(scriptedTarget);
        AkSoundEngine.SetState("EnemyState", "Investigate");
    }

    protected override void HandleEnd()
    {
        if(Enemy != null)
        {
            Enemy.SetActive(true);
            if(enemyAI != null)
            {
                SetTarget();
            }
        }
    }
}
