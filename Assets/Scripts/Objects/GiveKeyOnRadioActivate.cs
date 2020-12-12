using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveKeyOnRadioActivate : MonoBehaviour
{
    public event Action<string> OnKeyRecieve = delegate { };

    public RadioCompletionListSO radio;
    public KeyListSO keys;
    public RadioKeyExchange radioKey;
    IRadioMinigame minigame => GetComponent<IRadioMinigame>();

    // Start is called before the first frame update
    void Start()
    {
        if (minigame != null)
        {
            minigame.OnComplete += HandleComplete;
        }
    }

    void OnDestroy()
    {
        if (minigame != null)
        {
            minigame.OnComplete -= HandleComplete;
        }
    }

    //After completing a radio, check if that's enough completed radios to earn a specific key
    void HandleComplete()
    {
        if (radio != null)
        {
            if(radioKey.radioKeyExchange.ContainsKey(radio.completeCount))
            {
                if (!keys.IsKeyCollected(radioKey.radioKeyExchange[radio.completeCount])) 
                {
                    keys.keyStatuses[radioKey.radioKeyExchange[radio.completeCount]] = true;
                    OnKeyRecieve?.Invoke(radioKey.radioKeyExchange[radio.completeCount]);
                }
            }
        }
    }
}
