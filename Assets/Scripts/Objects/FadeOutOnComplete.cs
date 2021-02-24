using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutOnComplete : FadeOutBase
{
    public float delay = 0.1f;
    ICompleteGame Complete => GetComponent<ICompleteGame>();

    void Start()
    {
        if (Complete != null)
        {
            Complete.OnComplete += HandleComplete;
        }
    }

    private void HandleComplete()
    {
        StartCoroutine(FadeDelay());
    }
    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(delay);
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
