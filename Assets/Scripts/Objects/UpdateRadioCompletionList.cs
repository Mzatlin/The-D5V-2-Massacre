using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRadioCompletionList : MonoBehaviour
{
    public RadioCompletionListSO completion;
    public RadioSO radio;
    IRadioMinigame minigame => GetComponent<IRadioMinigame>();
    // Start is called before the first frame update
    void Start()
    {
        if (minigame != null)
        {
            minigame.OnComplete += HandleSuccess;
        }
        if (radio != null)
        {
            radio.location = transform.position;
        }
    }

    void OnDestroy()
    {
        if (minigame != null)
        {
            minigame.OnComplete -= HandleSuccess;
        }
    }

    private void HandleSuccess()
    {
        completion.LogRadio(radio,transform);
    }
}
