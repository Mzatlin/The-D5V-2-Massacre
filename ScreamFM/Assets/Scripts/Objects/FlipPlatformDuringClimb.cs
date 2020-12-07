using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlatformDuringClimb : MonoBehaviour
{
    private PlatformEffector2D platform;
    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            platform.rotationalOffset = 180;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            platform.rotationalOffset = 0;
        }
    }
}
