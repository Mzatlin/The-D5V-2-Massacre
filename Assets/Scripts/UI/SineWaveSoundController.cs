using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveSoundController : MonoBehaviour, ISineWaveSound
{

    Camera mainCamera => Camera.main;

    public void SetOutputSineWave(float value)
    {
        AkSoundEngine.SetRTPCValue("Current_Sine", value); //Set the Current Sine to the Initial Slider position
    }

    public void StopSineWave()
    {
        AkSoundEngine.PostEvent("Stop_Sines", mainCamera.gameObject);
    }


    public void StartSineWave(float value)
    {
        AkSoundEngine.SetRTPCValue("Correct_Sine", value); //Set the Correct Sine to the middle of Win Space
        AkSoundEngine.PostEvent("Play_Sines", mainCamera.gameObject);
    }

}
