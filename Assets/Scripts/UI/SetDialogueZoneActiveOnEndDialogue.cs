using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDialogueZoneActiveOnEndDialogue : DisableOnDialogueEndBase
{
    public List<GameObject> otherDialogueZones = new List<GameObject>();
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        foreach (GameObject other in otherDialogueZones)
        {
            other.SetActive(false);
        }
    }

    protected override void HandleEnd()
    {
        foreach (GameObject other in otherDialogueZones)
        {
            other.SetActive(true);
        }
    }
}
