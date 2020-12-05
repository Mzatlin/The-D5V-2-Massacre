using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour, IPlayerInputAxis
{
    float Inputx;
    float Inputy;
    IMovement movement;

    public float XMovement => Inputx;
    public float YMovement => Inputy;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<IMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputx = Input.GetAxis("Horizontal");
        if (movement != null)
        {
            movement.ApplyMovement(Inputx);
        }
    }
}
