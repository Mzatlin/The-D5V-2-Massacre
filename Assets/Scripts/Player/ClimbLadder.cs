using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    RaycastHit2D hit;
    [SerializeField]
    LayerMask ladderLayer;
    [SerializeField]
    float climbSpeed = 2f;
    bool isClimbing = false;
    float MoveY;
    Rigidbody2D rigidBody;
    Animator animate => GetComponentInChildren<Animator>();
    IPlayerState state;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        state = GetComponent<IPlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state.PlayerState.IsPlayerReady())
        {
            RayCastUpwards();
            Climb();
            AnimateMovement();
        }

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
            MoveY = 0;
        }
    }


    void Climb()
    {
        if(hit && isClimbing)
        {
            MoveY = Input.GetAxis("Vertical");
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, MoveY * climbSpeed);
            rigidBody.gravityScale = 0f;
        }
        else
        {
            rigidBody.gravityScale = 1f;
        }
    }

    void AnimateMovement()
    {
        if (animate != null)
        {
            animate.SetBool("IsClimbing", isClimbing);
            animate.SetFloat("MoveY", Mathf.Abs(MoveY));
        }
        else
        {
            Debug.Log("No animator found!");
        }
    }

}
