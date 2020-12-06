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
        if(collision.transform == enemy)
        {
            //if(direction != null && Mathf.Abs(direction.Direction.y) > 0.8)
            if (collision.rigidbody.velocity.x < (Mathf.Abs(0.1f)))
            {
                foreach (Collider2D collider in colliders)
                {
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider);
                }
            }
        }
    }


}

