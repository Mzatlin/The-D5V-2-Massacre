using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    IPlayerState state => GetComponent<IPlayerState>();
    IMovement movement => GetComponent<IMovement>();
    [SerializeField]
    float sprintAmount = 100f;
    [SerializeField]
    float moveSpeedMultiplier = 2f;
    float baseMovementSpeed;
    bool isSpriting = false;
    public float SprintAmount => sprintAmount;

    // Start is called before the first frame update
    void Start()
    {
        if(movement != null)
        {
            baseMovementSpeed = movement.MoveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state != null && state.PlayerState.IsPlayerReady())
        {
            TrySprint();
        }

        if (isSpriting)
        {
            sprintAmount -= 30 * Time.deltaTime;
        }
        else
        {
            sprintAmount += 10 * Time.deltaTime;
        }
        sprintAmount = Mathf.Clamp(sprintAmount, 0, 100);
    }

    void TrySprint()
    {
        if (sprintAmount > 1 && Input.GetKey(KeyCode.LeftShift))
        {
            if(movement != null && !isSpriting)
            {
                isSpriting = true;
                movement.MoveSpeed *= moveSpeedMultiplier;   
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isSpriting = false;
            }
            movement.MoveSpeed = baseMovementSpeed;
        }
        
    }
}
