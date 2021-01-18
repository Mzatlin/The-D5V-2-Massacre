using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HandleCompleteBase : MonoBehaviour
{
    public RadioCompletionListSO radio;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (radio != null)
        {
            radio.OnRadioComplete += HandleComplete;
        }
    }

    protected virtual void OnDestroy()
    {
        if (radio != null)
        {
            radio.OnRadioComplete -= HandleComplete;
        }
    }

    protected abstract void HandleComplete(Transform obj);
}
