using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionVelocityBase : MonoBehaviour
{
    [SerializeField]
    LayerMask allowedLayers;
    [SerializeField]
    Transform enemy;
    IEnemyDirection direction;
    Animator Animate => GetComponentInChildren<Animator>();
    Rigidbody2D rb;


    void Start()
    {
        if (enemy != null)
        {
            direction = enemy.GetComponent<IEnemyDirection>();
            rb = enemy.GetComponent<Rigidbody2D>();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & allowedLayers) != 0)
        {
            CheckAnimation();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & allowedLayers) != 0)
        {
            CheckAnimation();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & allowedLayers) != 0)
        {
            CheckAnimation();
        }
    }

    void CheckAnimation()
    {
        var directionX = Mathf.Abs(direction.Direction.x);
        var directionY = Mathf.Abs(direction.Direction.y);
        float difference = Mathf.Abs(directionX - directionY);
        if (Animate != null && ((direction != null && difference > 0.9)))
        {
            Animate.SetBool("IsEntering", true);
            Animate.SetBool("IsLeaving", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & allowedLayers) != 0)
        {
            if (Animate != null && (rb != null && Vector3.Distance(enemy.position,transform.position)>1))
            {
                Animate.SetBool("IsEntering", false);
                Animate.SetBool("IsLeaving", true);
            }
        }
    }
}
