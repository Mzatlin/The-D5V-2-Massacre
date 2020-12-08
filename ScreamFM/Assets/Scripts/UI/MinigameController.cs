using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameController : MonoBehaviour
{
    public Image dialImage;
    public Slider radioSlider;
    IRadioMinigame radio => GetComponent<IRadioMinigame>();
    float turnSpeed = 36f;
    float dialRotation = 0f;
    bool isPlayingGame;
    // Start is called before the first frame update
    void Start()
    {
       
        if(radio != null)
        {
            radio.OnMinigameStart += HandleMiniGameStart;
            radio.OnExit += HandleMiniGameExit;
        }
    }

    private void HandleMiniGameExit()
    {
        isPlayingGame = false;
    }

    private void HandleMiniGameStart()
    {
        isPlayingGame = true;
        dialImage.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        radioSlider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (dialImage != null && isPlayingGame)
        {
            dialRotation = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
            //dialRotation = Mathf.Clamp(dialRotation, -90, 90);
            //dialImage.rectTransform.rotation = Quaternion.identity * Quaternion.AngleAxis(dialRotation, dialImage.rectTransform.right);

            dialImage.rectTransform.Rotate(new Vector3(0, 0, -dialRotation));
            radioSlider.value += dialRotation / 360;
            radioSlider.value = Mathf.Clamp(radioSlider.value, 0f, 1f);

            if (dialImage.rectTransform.rotation.z >= 0.9 && dialImage.rectTransform.rotation.z <= -0.9)
            {

                 dialImage.rectTransform.rotation = Quaternion.Euler(0, 0, -90);
                // dialImage.rectTransform = Mathf.Clamp(dialImage.rectTransform.eulerAngles.z, -90, 90);
            }
            if(radioSlider.value >= 0.5 && radioSlider.value <= 0.53)
            {
                isPlayingGame = false;
                radio.ProcessSuccess();
            }

        }
    }
}
