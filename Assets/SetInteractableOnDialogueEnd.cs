using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteractableOnDialogueEnd : DisableOnDialogueEndBase
{
    public List<GameObject> interactables = new List<GameObject>();
    public GameObject setInactiveObject;
    protected override void HandleEnd()
    {
        foreach (GameObject interact in interactables)
        {
            var stats = interact.GetComponent<IInteractionStats>();
            if (stats != null)
            {
                SetObjectActive(stats, true);
            }
        }

        var stat = setInactiveObject.GetComponent<IInteractionStats>();
        if(stat != null)
        {
            SetObjectActive(stat, false);
        }
    }

    void SetObjectActive(IInteractionStats stats, bool isActive)
    {
        stats.CanInteract = isActive;
    }
}
