using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementPhysics : MonoBehaviour, IMovement
{
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float movementSpeedX;

    private Vector2 moveVelocity;
    private float moveDirectionX;

    public float MoveSpeed { get => movementSpeedX; set => movementSpeedX = value; }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void ApplyMovement(float xDirection)
    {
        moveDirectionX = xDirection;
     
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidBody != null)
        {
            moveVelocity = new Vector2(moveDirectionX * movementSpeedX * Time.fixedDeltaTime, rigidBody.velocity.y);
            rigidBody.velocity = moveVelocity;
        }

    }
}
