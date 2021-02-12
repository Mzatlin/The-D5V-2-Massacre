using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Lists/DialogueRadioComplete")]
public class RadioDialogueCompleteSO : ScriptableObject
{
    public List<string> dialogueRadioList = new List<string>();
    [SerializeField]
    int currentIndex;

    public void ResetDialogueIndex()
    {
        currentIndex = 0;
    }

    public int GetCurrentIndex()
    {
        return currentIndex;
    }

    public int IncrementIndex()
    {
        return currentIndex < dialogueRadioList.Count-1 ? currentIndex++ : currentIndex;
    }
}
