using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTension : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    void Update()
    {
        if (enemy.activeInHierarchy)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            AkSoundEngine.SetRTPCValue("Tension", dist);
        }
    }
}
