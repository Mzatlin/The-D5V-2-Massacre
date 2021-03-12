using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinigameController : MonoBehaviour
{
    public Image radioScreen;
    public Image radioAnswer;
    public TextMeshProUGUI wrongText;
    Animator radioScreenAnimation;
    Animator radioAnswerAnimation;
    IRadioMinigame radio => GetComponent<IRadioMinigame>();
    IRadioSlider slider => GetComponent<IRadioSlider>();
    ICameraShake cameraShake;
    [SerializeField]
    bool isPlayingGame = false;
    bool isOnTheSpot = false;
    bool canInput = true;
    float winSpaceMin = 0.5f;
    float winSpaceMax = 0.53f;
    float middleSpaceMin = 0.3f;
    float middleSpaceMax = 0.7f;
    IEnumerator stopInput = null;
    bool isDelayed = false;

    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        if(mainCamera != null)
        {
            cameraShake = mainCamera.GetComponent<ICameraShake>();
        }

        if(radioScreen != null && radioAnswer != null)
        {
            radioScreenAnimation = radioScreen.GetComponent<Animator>();
            radioAnswerAnimation = radioAnswer.GetComponent<Animator>();
        }

        if (radio != null)
        {
            radio.OnMinigameStart += HandleMiniGameStart;
            radio.OnExit += HandleMiniGameExit;
        }
        if(wrongText != null)
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
        if(cameraShake != null)
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
        AkSoundEngine.PostEvent("Stop_Sines", mainCamera.gameObject);
        isPlayingGame = false;
        Debug.Log(isPlayingGame);
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
        if(slider != null)
        {
            slider.ResetDialRotation();
            slider.SetRadioSliderValue(0.5f);
        }
        AkSoundEngine.SetRTPCValue("Current_Sine", 5); //Set the Current Sine to the Initial Slider position
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
            AkSoundEngine.SetRTPCValue("Correct_Sine", winSpaceMax * 10f); //Set the Correct Sine to the middle of Win Space
            AkSoundEngine.PostEvent("Play_Sines", mainCamera.gameObject);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (slider != null && isPlayingGame && canInput)
        {
            slider.RotateDial();
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
                radio.ProcessSuccess();
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
        radioScreenAnimation.speed = (slider.RadioSliderValue * 1.5f) + .3f; //Can be put in the dial animation class
        radioAnswerAnimation.speed = (slider.RadioSliderValue * 1.5f) + .3f;
        AkSoundEngine.SetRTPCValue("Current_Sine", slider.RadioSliderValue * 10f); //can be put in a sound class 

        if (slider.RadioSliderValue >= winSpaceMin && slider.RadioSliderValue <= winSpaceMax)
        {
            isOnTheSpot = true;
            radioScreenAnimation.SetBool("IsOnSpot", true);
            radioScreenAnimation.SetBool("IsOnMid", false);
        }
        else if (slider.RadioSliderValue >= middleSpaceMin && slider.RadioSliderValue <= middleSpaceMax)
        {
            isOnTheSpot = false;
            radioScreenAnimation.SetBool("IsOnSpot", false);
            radioScreenAnimation.SetBool("IsOnMid", true);
        }
        else
        {
            isOnTheSpot = false;
            radioScreenAnimation.SetBool("IsOnSpot", false);
            radioScreenAnimation.SetBool("IsOnMid", false);
        }
    }
}
