using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour, ISprint
{
    IPlayerState state => GetComponent<IPlayerState>();
    IMovement movement => GetComponent<IMovement>();
    IPlayerInputAxis playerInput => GetComponent<IPlayerInputAxis>();
    IClimb climb => GetComponent<IClimb>();

    [SerializeField]
    float moveSpeedMultiplier = 2f;
    [SerializeField]
    float climbSpeedMultipler = 2f;
    [SerializeField]
    float rechargeSpeed = 10f;
    [SerializeField]
    float depletionSpeed = 30f;
    [SerializeField]
    float rechargeDelay = 3f;
    bool isDelaying = false;
    bool canSprint = true;

    float baseMovementSpeed;
    bool isSprinting = false;
    public bool IsSprinting => isSprinting;
    public float SprintAmount { get; private set; } = 100f;

    Animator animate;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponentInChildren<Animator>();
        if (movement != null)
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
            ChangeSprintBar();
        }
        else
        {
            ChangeSprintBar();
            isSprinting = false;
            ResetSpeed();
        }

        SprintAmount = Mathf.Clamp(SprintAmount, 0, 100);

        AnimateMovement();
    }



    void ChangeSprintBar()
    {
        if (isSprinting && ((Mathf.Abs(playerInput.XMovement) > 0.1) || (Mathf.Abs(playerInput.YMovement) > 0.1 && climb.IsClimbing)))
        {
            SprintAmount -= depletionSpeed * Time.deltaTime;
        }
        else
        {
            TryRecharge();
        }
    }


    void TryRecharge()
    {
        if (SprintAmount < 1f && !isDelaying)
        {
            canSprint = false;
            if (!isDelaying)
            {
                StartCoroutine(Delay());
            }
            else
            {
                isDelaying = false;
                SprintAmount += rechargeSpeed * Time.deltaTime;
            }

        }
        else
        {
            isDelaying = false;
            SprintAmount += rechargeSpeed * Time.deltaTime;
        }
      
    }

    void TrySprint()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift) && !canSprint)
        {
            ResetSpeed();
            return;
        }

        if (SprintAmount > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            if (Mathf.Abs(playerInput.XMovement) > 0.1 || (Mathf.Abs(playerInput.YMovement) > 0.1 && climb.IsClimbing))
            {
                if (movement != null && climb != null && !isSprinting)
                {
                    isSprinting = true;
                    movement.MoveSpeed *= moveSpeedMultiplier;
                    climb.SetClimbSpeed(climbSpeedMultipler);
                }
            }
        }
        else
        {
            ResetSpeed();
        }

    }


    void ResetSpeed()
    {
        isSprinting = false;
        movement.MoveSpeed = baseMovementSpeed;
        climb.ResetClimbSpeed();
    }

    IEnumerator Delay()
    {

        yield return new WaitForSeconds(rechargeDelay);
        isDelaying = true;
    }

    void AnimateMovement()
    {
        if (animate != null)
        {
            animate.SetBool("IsRunning", isSprinting);
        }
        else
        {
            Debug.Log("No animator found!");
        }
    }
}
