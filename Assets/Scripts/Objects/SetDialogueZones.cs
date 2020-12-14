using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDialogueZones : MonoBehaviour
{

    public SaveStateSO save;
    public List<GameObject> dialogueZones = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        if (save.IsOpeningComplete)
        {
            HideDialogueZones();
        }
    }

    void HideDialogueZones()
    {
        foreach(GameObject dialogue in dialogueZones)
        {
            dialogue.SetActive(false);
        }
    }
}
