using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnableSuccessMessageOnInteract : MonoBehaviour
{


    IInteractable interact;
    public Canvas successCanvas;
    public string successMessage;
    public TextMeshProUGUI successText;
    // Start is called before the first frame update
    void Start()
    {
        interact = GetComponent<IInteractable>();
        if (interact != null)
        {
            interact.OnInteract += HandleInteract;
        }

        if(successCanvas != null)
        {
            successCanvas.enabled = false;
        }
    }

    private void OnDestroy()
    {
        if (interact != null)
        {
            interact.OnInteract -= HandleInteract;
        }
    }

    void HandleInteract()
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
