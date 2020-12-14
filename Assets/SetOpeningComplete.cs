using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOpeningComplete : DisableOnDialogueEndBase
{
    public SaveStateSO save;


    protected override void HandleEnd()
    {
       if(save != null)
        {
            save.IsOpeningComplete = true;
        }
    }
}
