using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameSliderController : MonoBehaviour, IRadioSlider
{

    public float RadioSliderValue => radioSlider.value;

    public Slider radioSlider;
    public Image dialImage;

    readonly float turnSpeed = 36f;
    float dialRotation = 0f;

    public void ResetDialRotation()
    {
        dialImage.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void SetRadioSliderValue(float value)
    {
        radioSlider.value = value;
    }

    public void RotateDial()
    {
        dialRotation = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        dialImage.rectTransform.Rotate(new Vector3(0, 0, -dialRotation));

        ClampDialRotation(dialRotation);
        UpdateRadioSlider(dialRotation);
    }

    void ClampDialRotation(float dialRotation)
    {
        if ((dialImage.rectTransform.rotation.z < -0.9999f && dialRotation > 0))
        {
            dialImage.rectTransform.rotation = Quaternion.Euler(0, 0, -180);
        }
        else if ((dialImage.rectTransform.rotation.z > 0.9999f) && dialRotation < 0)
        {
            dialImage.rectTransform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    void UpdateRadioSlider(float dialRotation)
    {
        radioSlider.value += dialRotation / 360;
        radioSlider.value = Mathf.Clamp(radioSlider.value, 0f, 1f);
    }

}
