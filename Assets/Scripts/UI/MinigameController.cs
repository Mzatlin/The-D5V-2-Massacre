using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinigameController : MonoBehaviour
{
    public TextMeshProUGUI wrongText;
    IRadioMinigame Radio => GetComponent<IRadioMinigame>();
    IRadioSlider RadioSlider => GetComponent<IRadioSlider>();
    ISineWaveAnimate Animation => GetComponent<ISineWaveAnimate>();
    ISineWaveSound Sound => GetComponent<ISineWaveSound>();
    ICameraShake cameraShake;
    bool isPlayingGame = false;
    bool isOnTheSpot = false;
    bool canInput = true;
    float winSpaceMin = 0.5f;
    float winSpaceMax = 0.53f;
    float middleSpaceMin = 0.3f;
    float middleSpaceMax = 0.7f;
    float correctSpeed = 0f;
    float outputSpeed = 0f;
    IEnumerator stopInput = null;
    bool isDelayed = false;

    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera != null)
        {
            cameraShake = mainCamera.GetComponent<ICameraShake>();
        }

        if (Radio != null)
        {
            Radio.OnMinigameStart += HandleMiniGameStart;
            Radio.OnExit += HandleMiniGameExit;
        }
        if (wrongText != null)
        {
            wrongText.enabled = false;
        }

        stopInput = StopInput();
    }

    void ToggleText()
    {
        if (wrongText != null)
        {
            wrongText.enabled = !wrongText.enabled;
        }
    }

    IEnumerator StopInput()
    {
        ToggleText();
        if (cameraShake != null)
        {
            cameraShake.TryShake(0.5f, 0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        ToggleText();
        canInput = true;
        isDelayed = false;
    }

    private void HandleMiniGameExit()
    {
        if (Sound != null)
        {
            Sound.StopSineWave();
        }
        isPlayingGame = false;
        canInput = true;
        StopCoroutine(stopInput);
        wrongText.enabled = false;
        if (cameraShake != null)
        {
            cameraShake.ResetShake();
        }
    }

    private void HandleMiniGameStart()
    {
        isPlayingGame = true;
        wrongText.enabled = false;
        if (RadioSlider != null)
        {
            RadioSlider.ResetDialRotation();
            RadioSlider.SetRadioSliderValue(0.5f);
        }
        if(Sound != null)
        {
            //Set the Current Sine to the Initial Slider position
            Sound.SetOutputSineWave(5f);
        }
        SetRadioValue();
    }

    void SetRadioValue()
    {
        middleSpaceMin = UnityEngine.Random.Range(0.01f, 0.59f);
        middleSpaceMax = middleSpaceMin + 0.4f;
        winSpaceMin = UnityEngine.Random.Range(middleSpaceMin + 0.1f, middleSpaceMax - 0.1f);
        winSpaceMax = winSpaceMin + 0.03f;

        if (Mathf.Abs(winSpaceMax - 0.5f) <= 0.1f || Mathf.Abs(winSpaceMin - 0.5f) <= 0.1f)
        {
            SetRadioValue();
        }
        else
        {
            if(Sound != null)
            {
                Sound.StartSineWave(winSpaceMax * 10f);
            }
            correctSpeed = ((winSpaceMax - 0.015f) * 1.5f) + .3f;
            Animation.SetCorrectSineWaveSpeed(correctSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RadioSlider != null && isPlayingGame && canInput)
        {
            RadioSlider.RotateDial();
            GetInputValidation();
        }
    }

    //Register Input key - Check the spot - if correct - Send complete event - Else - prevent dial input
    void GetInputValidation()
    {
        CheckSpot();
        if (isPlayingGame && Input.GetKeyDown(KeyCode.W))
        {
            if (isOnTheSpot)
            {
                isPlayingGame = false;
                isOnTheSpot = false;
                Radio.ProcessSuccess();
            }
            else
            {
                if (!isDelayed)
                {
                    canInput = false;
                    isDelayed = true;
                    StartCoroutine(StopInput());
                }
            }
        }

    }

    //Animate Bottom Frequency Sprite based on how close the slider is to the point
    void CheckSpot()
    {
        outputSpeed = (RadioSlider.RadioSliderValue * 1.5f) + .3f;
        Animation.SetOutputSineWaveSpeed(outputSpeed);
        if(Sound != null)
        {
            Sound.SetOutputSineWave(RadioSlider.RadioSliderValue * 10f);
        }
        if (RadioSlider.RadioSliderValue >= winSpaceMin && RadioSlider.RadioSliderValue <= winSpaceMax)
        {
            isOnTheSpot = true;
            SetAnimation(isOnTheSpot);
        }
        else if (RadioSlider.RadioSliderValue >= middleSpaceMin && RadioSlider.RadioSliderValue <= middleSpaceMax)
        {
            isOnTheSpot = false;
            SetAnimation(isOnTheSpot);
        }
        else
        {
            isOnTheSpot = false;
            if (Animation != null)
            {
                Animation.ResetSignWave();
            }
        }
    }

    void SetAnimation(bool state)
    {
        if (Animation != null)
        {
            Animation.AnimateSignWave(state);
        }
    }
}
