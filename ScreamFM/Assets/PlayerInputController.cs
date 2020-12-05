using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour, IPlayerInputAxis
{
    float Inputx;
    float Inputy;
    bool isFacingRight = true;
    IMovement movement;
    Vector2 playerScale;

    public float XMovement => Inputx;
    public float YMovement => Inputy;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<IMovement>();
        playerScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Inputx = Input.GetAxis("Horizontal");
        if (movement != null)
        {
            movement.ApplyMovement(Inputx);
        }

        if ((Inputx < 0.0f) != isFacingRight)
        {

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
}
