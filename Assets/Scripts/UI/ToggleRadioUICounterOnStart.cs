using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRadioUICounterOnStart : MonoBehaviour
{
    public SaveStateSO save;
    public RadioDialogueCompleteSO dialogue;
    public Canvas RadioUI;
    // Start is called before the first frame update
    void Start()
    {
        if(RadioUI != null)
        {
            RadioUI.enabled = false;
        }
        if(save != null)
        {
            ToggleRadioUI();
        }
        if(dialogue != null)
        {
            dialogue.ResetDialogueIndex();
        }
    }

    void ToggleRadioUI()
    {
        if(RadioUI == null || save == null)
        {
            return;
        }

        if (save.IsOpeningComplete)
        {
            RadioUI.enabled = true;
        }
        else
        {
            RadioUI.enabled = false;
        }
    }
}
