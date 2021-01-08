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
        var directionX = Mathf.Abs(direction.Direction.x);
        var directionY = Mathf.Abs(direction.Direction.y);
        float difference = Mathf.Abs(directionX - directionY);
        if (direction != null && difference > 0.9)
        {
            foreach (Collider2D collider in colliders)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider);
            }
            StartCoroutine(IgnoreDelay(collision));
        }
        else
        {
            foreach (Collider2D collider in colliders)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, false);
            }
        }
    }


    //Recursively check if the object is still eligible for ignorecollision after given delay 
    IEnumerator IgnoreDelay(Collision2D collision)
    {
        yield return new WaitForSeconds(.5f);
        foreach (Collider2D collider in colliders)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, false);
        }
        CheckCollision(collision);

    }


}

