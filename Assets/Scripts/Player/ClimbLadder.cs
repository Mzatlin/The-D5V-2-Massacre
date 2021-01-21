using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour, IClimb
{
    RaycastHit2D hit;
    [SerializeField]
    LayerMask ladderLayer;
    [SerializeField]
    float baseClimbSpeed = 100f;
    float climbSpeed = 2f;
    bool isClimbing = false;
    float MoveY;
    Rigidbody2D rigidBody;
    Animator animate => GetComponentInChildren<Animator>();

    public bool IsClimbing => isClimbing;

    IPlayerState state => GetComponent<IPlayerState>();
    // Start is called before the first frame update
    void Start()
    {
        climbSpeed = baseClimbSpeed;
        rigidBody = GetComponent<Rigidbody2D>();
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
        else
        {
            rigidBody.velocity = Vector2.zero;
            rigidBody.gravityScale = 0f;
            AnimateMovement();
        }

    }

    void RayCastUpwards()
    {
        Ray2D ray = new Ray2D(transform.position, Vector2.up);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        hit = Physics2D.Raycast(ray.origin, ray.direction, 1f, ladderLayer);
        if (hit)
        {
            Debug.Log("Hit!");
            isClimbing = true;
            Climb();
        }
        else
        {
            isClimbing = false;
            MoveY = 0;
        }
    }


    void Climb()
    {
        if (hit && isClimbing)
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
            if (isClimbing)
            {
                animate.SetBool("IsClimbing", isClimbing);
                if (state.PlayerState.IsPlayerReady())
                {

                    animate.SetFloat("MoveY", Mathf.Abs(MoveY));
                }
                else
                {
                    animate.SetFloat("MoveY", 0);
                }

            }
            else
            {
                animate.SetFloat("MoveY", 0);
                animate.SetBool("IsClimbing", false);
            }

            if(climbSpeed > 2f)
            {
                animate.speed = 1.5f;
            }
            else
            {
                animate.speed = 1f;
            }

        }
        else
        {
            Debug.Log("No animator found!");
        }
    }

    public void SetClimbSpeed(float newSpeedMultiplier)
    {
        climbSpeed *= newSpeedMultiplier;
    }

    public void ResetClimbSpeed()
    {
        climbSpeed = baseClimbSpeed;
    }
}
