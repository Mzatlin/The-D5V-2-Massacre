using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateSineWave : MonoBehaviour, ISineWaveAnimate
{
    public Image frequencyOutput;
    public Image correctFrequency;
    Animator frequencyOutputAnimation;
    Animator correctFrequencyAnimation;

    // Start is called before the first frame update
    void Start()
    {
        if (frequencyOutput != null && correctFrequency != null)
        {
            frequencyOutputAnimation = frequencyOutput.GetComponent<Animator>();
            correctFrequencyAnimation = correctFrequency.GetComponent<Animator>();
        }
    }

    public void SetCorrectSineWaveSpeed(float amount)
    {
        correctFrequencyAnimation.speed = amount;
    }

    public void SetOutputSineWaveSpeed(float amount)
    {
        frequencyOutputAnimation.speed = amount; 
    }

    public void AnimateSignWave(bool animState)
    {
        if(frequencyOutputAnimation != null)
        {
            frequencyOutputAnimation.SetBool("IsOnSpot", animState);
            frequencyOutputAnimation.SetBool("IsOnMid", !animState);
        }
    }

    public void ResetSignWave()
    {
        if (frequencyOutputAnimation != null)
        {
            frequencyOutputAnimation.SetBool("IsOnSpot", false);
            frequencyOutputAnimation.SetBool("IsOnMid", false);
        }
    }
}
