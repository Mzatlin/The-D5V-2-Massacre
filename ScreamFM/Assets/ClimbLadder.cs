using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    RaycastHit2D hit;
    [SerializeField]
    LayerMask ladderLayer;
    bool isClimbing = false;
    float MoveY;
    Rigidbody2D rigidBody;
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RayCastUpwards();
        Climb();
    }

    void RayCastUpwards()
    {
        Ray2D ray = new Ray2D(transform.position, Vector2.up);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        hit = Physics2D.Raycast(ray.origin, ray.direction, 8f, ladderLayer);
        if (hit)
        {
          //  if (Input.GetKeyDown(KeyCode.E))
          //  {
                isClimbing = true;
                Climb();
           // }
        }
        else
        {
            isClimbing = false;
        }
    }


    void Climb()
    {
        if(hit && isClimbing)
        {
            MoveY = Input.GetAxis("Vertical");
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, MoveY * speed);
            rigidBody.gravityScale = 0f;
        }
        else
        {
            rigidBody.gravityScale = 1f;
        }
    }

}
