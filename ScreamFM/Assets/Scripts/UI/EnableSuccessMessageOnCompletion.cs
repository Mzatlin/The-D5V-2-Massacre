using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableSuccessMessageOnCompletion : MonoBehaviour
{
    public Canvas successCanvas;
    public string successMessage;
    public TextMeshProUGUI successText;
    IRadioMinigame minigame => GetComponent<IRadioMinigame>();
    // Start is called before the first frame update
    void Start()
    {
        if (successCanvas != null)
        {
            successCanvas.enabled = false;
        }
        if(minigame != null)
        {
            minigame.OnComplete += HandleSuccess;
        }
    }

    void OnDestroy()
    {
        if (minigame != null)
        {
            minigame.OnComplete -= HandleSuccess;
        }
    }

    void HandleSuccess()
    {
        successCanvas.enabled = true;
        successText.text = successMessage;
        StartCoroutine(DisableDelay());
    }

    IEnumerator DisableDelay()
    {
        yield return new WaitForSeconds(3f);
        successCanvas.enabled = false;
    }
}
