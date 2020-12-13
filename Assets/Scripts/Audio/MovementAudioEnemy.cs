using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAudioEnemy : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    void EnemyWalkingAudio()
    {
        AkSoundEngine.SetState("Locomotion", "Walking");
        AkSoundEngine.PostEvent("Play_FootstepsEnemy", mainCamera);
    }

    void EnemyRunningAudio()
    {
        AkSoundEngine.SetState("Locomotion", "Running");
        AkSoundEngine.PostEvent("Play_FootstepsEnemy", mainCamera);
    }
}
