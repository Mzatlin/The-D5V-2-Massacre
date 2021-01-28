using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionByClimbing : MonoBehaviour
{
    [SerializeField]
    Transform player;
    public Collider2D[] colliders;
    IClimb climb;
    Rigidbody2D rb;
    float DirectionY => Input.GetAxis("Vertical");
    // Start is called before the first frame update
    void Start()
    {
        colliders = player.GetComponents<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        if(player != null)
        {
           climb = player.gameObject.GetComponent<IClimb>();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
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
        if (Mathf.Abs(DirectionY) > 0.01 || climb.IsClimbing)
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
        if(climb.IsClimbing == false)
        {
            foreach (Collider2D collider in colliders)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, false);
            }
        }
        CheckCollision(collision);

    }

}
