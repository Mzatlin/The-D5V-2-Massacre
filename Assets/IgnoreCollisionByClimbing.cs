using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionByClimbing : MonoBehaviour
{
    [SerializeField]
    Transform player;
    public Collider2D[] colliders;
    Rigidbody2D rb;
    float DirectionY => Input.GetAxis("Vertical");
    // Start is called before the first frame update
    void Start()
    {
        colliders = player.GetComponents<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(DirectionY);
        if (collision.transform == player)
        {
            CheckCollision(collision);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform == player)
        {
            CheckCollision(collision);
        }
    }

    void CheckCollision(Collision2D collision)
    { 
        if (Mathf.Abs(DirectionY) > 0.01/*((directionX < 0.5f /*&& directionX > 0.8f) && (/*directionY < 0.9f &&  directionY > 0.5f)*/ /*&& (Mathf.Abs(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x) < 0.9f))*/)
        {
            foreach (Collider2D collider in colliders)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider);
            }
        }
        else
        {
            foreach (Collider2D collider in colliders)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, false);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (Mathf.Abs(DirectionY) < 0.1)
        {
            foreach (Collider2D collider in colliders)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, false);
            }
        }
    }

}
