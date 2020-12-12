using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableSuccessMessageOnInteract : HandleInteractionBase
{
    public Canvas successCanvas;
    public string successMessage;
    public TextMeshProUGUI successText;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(successCanvas != null)
        {
            successCanvas.enabled = false;
            successText.text = "";
        }
    }

    protected override void HandleInteract()
    {
        successCanvas.enabled = true;
        successText.text = successMessage;
        StartCoroutine(DisableDelay());
    }

    IEnumerator DisableDelay()
    {
        yield return new WaitForSeconds(3f);
        successText.text = "";
        successCanvas.enabled = false;
    }
}
