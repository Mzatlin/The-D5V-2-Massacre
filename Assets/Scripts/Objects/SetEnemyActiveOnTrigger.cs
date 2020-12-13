using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyActiveOnTrigger : MonoBehaviour
{
    public GameObject Enemy;
    public LayerMask playerMask;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if ((playerMask & 1 << collider.gameObject.layer) != 0)
        {
            Enemy.SetActive(true);
        }
    }
}
