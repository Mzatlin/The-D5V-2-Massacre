using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAudio : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    void WalkingAudio()
    {
        AkSoundEngine.SetState("Locomotion", "Walking");
        AkSoundEngine.PostEvent("Play_Footsteps", mainCamera);
    }

    void RunningAudio()
    {
        AkSoundEngine.SetState("Locomotion", "Running");
        AkSoundEngine.PostEvent("Play_Footsteps", mainCamera);
    }

    void ClimbingAudio()
    {
        AkSoundEngine.PostEvent("Play_LadderClimb", mainCamera);
    }
}
