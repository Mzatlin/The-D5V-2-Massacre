using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour, IPlayerInputAxis
{
    float Inputx;
    float Inputy;
    IMovement movement;
    IPlayerState state;
    IFlipPlayer flip;
    Animator animate;

    public float XMovement => Inputx;
    public float YMovement => Input.GetAxis("Vertical");

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<IMovement>();
        state = GetComponent<IPlayerState>();
        animate = GetComponentInChildren<Animator>();
        flip = GetComponent<IFlipPlayer>();
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
            if(movement != null)
            {
                movement.ApplyMovement(0f);
            }
        }
    }

    void MovePlayer()
    {
        Inputx = Input.GetAxis("Horizontal");
        if (movement != null)
        {
            movement.ApplyMovement(Inputx);
        }
        if(flip != null)
        {
            flip.FlipPlayer();
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
