using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutOnComplete : FadeOutBase
{
    ICompleteGame Complete => GetComponent<ICompleteGame>();
    // Start is called before the first frame update

    void Start()
    {
        if (Complete != null)
        {
            Complete.OnComplete += HandleComplete;
        }
    }

    private void HandleComplete()
    {
        FadeOut();
    }

    void OnDestroy()
    {
        if (Complete != null)
        {
            Complete.OnComplete -= HandleComplete;
        }
    }

}
