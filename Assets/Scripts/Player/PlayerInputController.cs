using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour, IPlayerInputAxis
{
    float Inputx;
    float Inputy;
    bool isFacingRight = true;
    IMovement movement;
    IPlayerState state;
    Vector2 playerScale;
    Animator animate;

    public float XMovement => Inputx;
    public float YMovement => Input.GetAxis("Vertical");

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<IMovement>();
        playerScale = transform.localScale;
        state = GetComponent<IPlayerState>();
        animate = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state.PlayerState.IsPlayerReady())
        {
            MovePlayer();
            AnimateMovement();
        }
        else
        {
            AnimateMovement();
            movement.ApplyMovement(0f);
        }
    }

    void MovePlayer()
    {
        Inputx = Input.GetAxis("Horizontal");
        if (movement != null)
        {
            movement.ApplyMovement(Inputx);
        }
        FlipPlayer();
    }

    void FlipPlayer()
    {
        if ((Inputx >= 0.0f) != isFacingRight)
        {
            isFacingRight = !isFacingRight;
            playerScale.x *= -1;
            transform.localScale = playerScale;
        }
    }

    void AnimateMovement()
    {
        if(animate != null)
        {
            if (state.PlayerState.IsPlayerReady())
            {
                animate.SetFloat("MoveX", Mathf.Abs(Inputx));
            }
            else
            {
                animate.SetFloat("MoveX", 0);
            }
        }
        else
        {
            Debug.Log("No animator found!");
        }
    }
}
