using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateVentOnCollision : MonoBehaviour
{
    [SerializeField]
    LayerMask allowedLayers;
    Animator Animate => GetComponentInChildren<Animator>();


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(((1 << collision.gameObject.layer) & allowedLayers) != 0)
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

    void CheckAnimation()
    {
        if (Animate != null)
        {
            Animate.SetBool("IsEntering", true);
            Animate.SetBool("IsLeaving", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & allowedLayers) != 0)
        {
            if (Animate != null)
            {
                Animate.SetBool("IsEntering", false);
                Animate.SetBool("IsLeaving", true);
            }
        }
    }


}

