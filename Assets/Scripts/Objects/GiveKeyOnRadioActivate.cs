using System;
using UnityEngine;

public class GiveKeyOnRadioActivate : HandleCompleteBase
{
    public event Action<string> OnKeyRecieve = delegate { };

    public KeyListSO keys;
    public RadioKeyExchange radioKey;

    //After completing a radio, check if that's enough completed radios to earn a specific key
    protected override void HandleComplete(Transform obj)
    {
        if (radio != null)
        {
            if (radioKey.radioKeyExchange.ContainsKey(radio.completeCount))
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
