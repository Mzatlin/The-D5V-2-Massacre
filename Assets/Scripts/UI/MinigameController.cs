using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameController : MonoBehaviour
{
    public Image dialImage;
    public Image radioScreen;
    public Image radioAnswer;
    Animator radioScreenAnimation;
    Animator radioAnswerAnimation;
    public Slider radioSlider;
    IRadioMinigame radio => GetComponent<IRadioMinigame>();
    [SerializeField]
    float turnSpeed = 36f;
    float dialRotation = 0f;
    bool isPlayingGame = false;
    bool isOnTheSpot = false;
    float winSpaceMin = 0.5f;
    float winSpaceMax = 0.53f;
    float middleSpaceMin = 0.3f;
    float middleSpaceMax = 0.7f;

    [SerializeField] GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    private void HandleMiniGameExit()
    {
        AkSoundEngine.PostEvent("Stop_Sines", mainCamera);
        isPlayingGame = false;
    }

    private void HandleMiniGameStart()
    {
        isPlayingGame = true;
        dialImage.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        radioSlider.value = 0.5f;
        AkSoundEngine.SetRTPCValue("Current_Sine", 5); //Set the Current Sine to the Initial Slider position
        SetRadioValue();
    }

    void SetRadioValue()
    {
        middleSpaceMin = UnityEngine.Random.Range(0.01f, 0.59f);
        middleSpaceMax = middleSpaceMin + 0.4f;
        winSpaceMin = UnityEngine.Random.Range(middleSpaceMin + 0.1f, middleSpaceMax - 0.1f);
        winSpaceMax = winSpaceMin + 0.03f;
        AkSoundEngine.SetRTPCValue("Correct_Sine", winSpaceMin + 0.015f); //Set the Correct Sine to the middle of Win Space

        if (Mathf.Abs(winSpaceMax - 0.5f) <= 0.1f || Mathf.Abs(winSpaceMin - 0.5f) <= 0.1f)
        {
            SetRadioValue();
        }
        else
        {
            AkSoundEngine.PostEvent("Play_Sines", mainCamera);
        }    
    }

    // Update is called once per frame
    void Update()
    {

        if (dialImage != null && isPlayingGame)
        {
            RotateDial();
            GetInputValidation();
        }
    }

    void RotateDial()
    {
        dialRotation = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        dialImage.rectTransform.Rotate(new Vector3(0, 0, -dialRotation));

        radioSlider.value += dialRotation / 360;
        radioSlider.value = Mathf.Clamp(radioSlider.value, 0f, 1f);
        radioScreenAnimation.speed = (radioSlider.value * 1.5f)+.3f;
        radioAnswerAnimation.speed = (radioSlider.value * 1.5f) + .3f;
        AkSoundEngine.SetRTPCValue("Current_Sine", radioSlider.value * 10f);

        if ((dialImage.rectTransform.rotation.z < -0.9999f && dialRotation > 0))
        {
            dialImage.rectTransform.rotation = Quaternion.Euler(0, 0, -180);
        }
        else if ((dialImage.rectTransform.rotation.z > 0.9999f) && dialRotation < 0)
        {
            dialImage.rectTransform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    void GetInputValidation()
    {
        if (Input.GetKeyDown(KeyCode.W) && isOnTheSpot)
        {
            isPlayingGame = false;
            radio.ProcessSuccess();
        }

        if (radioSlider.value >= winSpaceMin && radioSlider.value <= winSpaceMax)
        {
            isOnTheSpot = true;
            radioScreenAnimation.SetBool("IsOnSpot", true);
            radioScreenAnimation.SetBool("IsOnMid", false);
          //  SetRadioScreen(Color.green);
        }
        else if (radioSlider.value >= middleSpaceMin && radioSlider.value <= middleSpaceMax)
        {
            isOnTheSpot = false;
            radioScreenAnimation.SetBool("IsOnSpot", false);
            radioScreenAnimation.SetBool("IsOnMid", true);
         //   SetRadioScreen(Color.yellow);
        }
        else
        {
            isOnTheSpot = false;
            radioScreenAnimation.SetBool("IsOnSpot", false);
            radioScreenAnimation.SetBool("IsOnMid", false);
         //   SetRadioScreen(Color.white);
        }
    }

    void SetRadioScreen(Color color)
    {
        if (radioScreen != null)
        {
            radioScreen.color = color;
        }
    }
}
