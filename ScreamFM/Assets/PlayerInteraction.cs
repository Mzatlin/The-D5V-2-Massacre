using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    RaycastHit2D hit;
    IInteractable interact;
    IPlayerInputAxis axis;
    IPlayerState state;
    Rigidbody2D rigidBody;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    float lookDistance = 13f;
    Vector2 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        axis = GetComponent<IPlayerInputAxis>();
        state = GetComponent<IPlayerState>();
        lastPosition = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (state.PlayerState.IsPlayerReady())
        {
            CastInteractionRay();
        }

    }

    void CastInteractionRay()
    {
        if(Mathf.Abs(rigidBody.velocity.x) > 0.1)
        {
            lastPosition = rigidBody.velocity;
        }
        Ray2D ray = new Ray2D(transform.position, lastPosition);
  
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
        hit = Physics2D.Raycast(ray.origin, ray.direction,lookDistance,mask);
        if(hit)
        {
            interact = hit.collider.transform.GetComponent<IInteractable>();
            if(interact != null)
            {
                interact.EnterInteractionRange();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interact.StartInteraction();
                }
            }
        }
        else
        {
            if(interact != null)
            {
              interact.LeaveInteractionRange();
            }
        }
    }
}
