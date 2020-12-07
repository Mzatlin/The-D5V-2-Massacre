using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionByVelocity : MonoBehaviour
{
    [SerializeField]
    Transform enemy;
    public Collider2D[] colliders;
    IEnemyDirection direction;
    // Start is called before the first frame update
    void Start()
    {
        colliders = enemy.GetComponents<Collider2D>();
        direction = enemy.GetComponent<IEnemyDirection>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == enemy)
        {
            CheckCollision(collision);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform == enemy)
        {
            CheckCollision(collision);
        }
    }

    void CheckCollision(Collision2D collision)
    {
        if (direction != null && Mathf.Abs(direction.Direction.x) < 0.8f)
        {
            foreach (Collider2D collider in colliders)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider);
            }
        }
    }


}

