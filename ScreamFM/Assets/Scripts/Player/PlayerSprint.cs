using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    IPlayerState state => GetComponent<IPlayerState>();
    IMovement movement => GetComponent<IMovement>();

    [SerializeField]
    float moveSpeedMultiplier = 2f;
    [SerializeField]
    float rechargeSpeed = 10f;
    [SerializeField]
    float depletionSpeed = 30f;
    [SerializeField]
    float rechargeDelay = 3f;
    bool hasDelayed = false;
 
    float baseMovementSpeed;
    bool isSpriting = false;
    public float SprintAmount { get; private set; } = 100f;

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
            SprintAmount -= depletionSpeed * Time.deltaTime;
        }
        else
        {
            TryRecharge();
        }

        SprintAmount = Mathf.Clamp(SprintAmount, 0, 100);
    }

    void TryRecharge()
    {
        if (SprintAmount < 3f && !hasDelayed)
        {
            StartCoroutine(Delay());
        }
        else
        {
            hasDelayed = false;
            SprintAmount += rechargeSpeed * Time.deltaTime;
        }
    }

    void TrySprint()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ResetSpeed();
            return;
        }

        if (SprintAmount > 1 && Input.GetKey(KeyCode.LeftShift))
        {
            if(movement != null && !isSpriting)
            {
                isSpriting = true;
                movement.MoveSpeed *= moveSpeedMultiplier;   
            }
        }
        else
        {
            ResetSpeed();
            movement.MoveSpeed = baseMovementSpeed;
        }
        
    }
    void ResetSpeed()
    {
        isSpriting = false;
        movement.MoveSpeed = baseMovementSpeed;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(rechargeDelay);
        hasDelayed = true;
    }
}
