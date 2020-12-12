using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EnableSuccessMessageOnKeyReceive : MonoBehaviour
{
    public Canvas successCanvas;
    string successMessage;
    public TextMeshProUGUI successText;
    GiveKeyOnRadioActivate key => GetComponent<GiveKeyOnRadioActivate>();
    // Start is called before the first frame update
     void Start()
    {
        if (successCanvas != null)
        {
            successCanvas.enabled = false;
            successText.text = "";
        }
        if(key != null)
        {
            key.OnKeyRecieve += HandleKeyReceive;
        }

    }

    private void OnDestroy()
    {
        if(key != null)
        {
            key.OnKeyRecieve -= HandleKeyReceive;
        }
    }

    void HandleKeyReceive(string message)
    {
        successMessage = message;
        successCanvas.enabled = true;
        successText.text = successMessage + " Key Found";
        StartCoroutine(DisableDelay());
    }

    IEnumerator DisableDelay()
    {
        yield return new WaitForSeconds(3f);
        successText.text = "";
        successCanvas.enabled = false;
    }
}
