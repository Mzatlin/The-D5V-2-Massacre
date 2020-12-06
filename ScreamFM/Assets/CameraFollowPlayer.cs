using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public float offset = 0.125f;
    [SerializeField]
    Vector3 offsetPosition = Vector3.zero;
    Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraOffset = Vector3.Lerp(target.position+offsetPosition, cameraOffset, offset);
        transform.position = cameraOffset;
    }
}
