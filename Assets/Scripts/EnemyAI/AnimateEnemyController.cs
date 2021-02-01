using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateEnemyController : MonoBehaviour
{
    Animator Animate => GetComponentInChildren<Animator>();
    IEnemyState StateMachine => GetComponent<IEnemyState>();
    Rigidbody2D Rb => GetComponent<Rigidbody2D>();
    public LayerMask ladderMask;

    void Update()
    {
        AnimateEnemy();
        SetMovement();
        SetClimb();
    }

    void AnimateEnemy()
    {
        if (StateMachine != null && 
            StateMachine.CurrentState.GetType() == typeof(ChasePlayerState) || StateMachine.CurrentState.GetType() == typeof(InvestigateObjectState))
        {
            Animate.SetBool("IsRunning", true);
        }
        else
        {
            Animate.SetBool("IsRunning", false);
        }
       
    }

    void SetMovement()
    {
        if(Mathf.Abs(Rb.velocity.x) <= .3f && (Mathf.Abs(Rb.velocity.y) <= .3f))
        {
            Animate.SetBool("IsStopped", true);
            Animate.SetBool("IsClimbing", false);
        }
        else
        {
            Animate.SetBool("IsStopped", false);
        }
    }

    void SetClimb()
    {
        Animate.SetFloat("MoveY", Mathf.Abs(Rb.velocity.y));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if((ladderMask & 1<<collision.gameObject.layer) != 0){
            Animate.SetBool("IsClimbing", true);
        }
    }
   void OnTriggerExit2D(Collider2D collision)
    {
        if ((ladderMask & 1 << collision.gameObject.layer) != 0)
        {
            Animate.SetBool("IsClimbing", false);
        }
    }
}
