using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    ICameraShake shake => GetComponent<ICameraShake>();
    public float offset = 0.125f;
    [SerializeField]
    Vector3 offsetPosition = Vector3.zero;
    Vector3 cameraOffset;

    // Update is called once per frame
    void LateUpdate()
    {
        if(shake == null || !shake.IsShaking)
        {
            cameraOffset = Vector3.Lerp(target.position + offsetPosition, cameraOffset, offset);
            transform.position = cameraOffset;
        }
    }
}
