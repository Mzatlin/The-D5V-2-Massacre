using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeedOnCollision : MonoBehaviour
{
    public float speed = 100f;
    [SerializeField] float originalSpeed = 300f;
    public LayerMask enemyMask;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((enemyMask & 1 << collision.gameObject.layer) != 0)
        {
            var pathSpeed = collision.gameObject.GetComponent<IEnemyPath>();
            if (pathSpeed != null)
            {
                pathSpeed.ObjectSpeed += speed;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((enemyMask & 1 << collision.gameObject.layer) != 0)
        {
            var pathSpeed = collision.gameObject.GetComponent<IEnemyPath>();
            if (pathSpeed != null)
            {
                pathSpeed.ObjectSpeed = originalSpeed;
            }
        }
    }
}
