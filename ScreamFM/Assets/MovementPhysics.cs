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

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void ApplyMovement(float xDirection)
    {
      moveVelocity = new Vector2(xDirection * movementSpeedX * Time.deltaTime, rigidBody.velocity.y);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigidBody != null)
        {
            rigidBody.velocity = moveVelocity;
        }

    }
}
