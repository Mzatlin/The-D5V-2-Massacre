using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRadioUICounterOnDialogueEnd : DisableOnDialogueEndBase
{
    public Canvas radioUI;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void HandleEnd()
    {
        if(radioUI != null)
        {
            radioUI.enabled = true;
        }
    }
}
