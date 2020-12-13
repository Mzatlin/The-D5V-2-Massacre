using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanPathControllerDuringDialogue : DisableOnDialogueEndBase
{
    public float deactivatePathDelay = 0.5f;
    public GameObject enemyGameObject;
    bool setPathingTo = false;
    EnemyAI enemy;
   

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if (enemyGameObject != null)
        {
            enemy = enemyGameObject.GetComponent<EnemyAI>();
        }

    }
    protected override void HandleEnd()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(deactivatePathDelay);
        if(enemy != null)
        {
            enemy.SetCanPath();
        }
    }
}
