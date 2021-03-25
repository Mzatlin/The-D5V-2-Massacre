using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayerSpriteController : MonoBehaviour, IFlipPlayer
{
    IPlayerLookDirection LookDirection => GetComponent<IPlayerLookDirection>();
    Vector2 playerScale;
    bool isFacingRight = true;


    void Start()
    {
        playerScale = transform.localScale;
    }

    public void FlipPlayer()
    {
        if (isFacingRight && Vector2.Dot(LookDirection.LastLookDirection, transform.right) < 0)
        {
            PerformFlip();
        }
        else if (!isFacingRight && Vector2.Dot(LookDirection.LastLookDirection, transform.right) > 0)
        {
            PerformFlip();
        }
    }

    void PerformFlip()
    {
        isFacingRight = !isFacingRight;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }


}
