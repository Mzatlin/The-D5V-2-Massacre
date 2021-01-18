using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetDialogueOnRadioComplete : HandleCompleteBase, IActivateDialogue
{
    public event Action OnActivateDialogue = delegate { };

    public RadioDialogueCompleteSO dialogues;
    public List<int> radioCounts = new List<int>();
    DialogueController dialogueWriter;

    protected override void Start()
    {
        base.Start();
        dialogueWriter = GetComponent<DialogueController>();
    }

    protected override void HandleComplete(Transform obj)
    {
        if (radio != null && dialogues != null)
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
        int nextDialogueCount = radioCounts[dialogues.GetCurrentIndex()];
        if (radio.completeCount == nextDialogueCount)
        {
            SetContentOfDialogueController(dialogues.dialogueRadioList[dialogues.GetCurrentIndex()]);
            OnActivateDialogue();
            dialogues.IncrementIndex();
        }
    }

    void SetContentOfDialogueController(string content)
    {
        dialogueWriter.SetContentText(content);
    }
}
