using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveKeyOnRadioActivate : MonoBehaviour
{
    public RadioCompletionListSO radio;
    public KeyListSO keys;
    public string keyName;
    IRadioMinigame minigame => GetComponent<IRadioMinigame>();
    [SerializeField]
    int amountForKey = 4;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (minigame != null)
        {
            minigame.OnComplete += HandleComplete;
        }
    }

    private void HandleComplete()
    {
        if (radio != null)
        {
            foreach (KeyValuePair<RadioSO, bool> complete in radio.radioStatuses)
            {
                if (complete.Value == true)
                {
                    counter++;
                }
            }

            if(counter == amountForKey)
            {
                if (!keys.IsKeyCollected(keyName))
                {
                    keys.keyStatuses[keyName] = true;
                }
            }
        }
    }
}
