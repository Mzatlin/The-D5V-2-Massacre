using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteractables : MonoBehaviour
{
    [SerializeField]
    List<GameObject> interatables = new List<GameObject>();
    public GameObject setInactiveObject;
    public SaveStateSO save;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        if (save != null)
        {
            if (!save.IsOpeningComplete)
            {
                DisableInteractables();
            }
            else
            {
                var stat = setInactiveObject.GetComponent<IInteractionStats>();
                if (stat != null)
                {
                    SetObjectActive(stat, false);
                }
            }
        }
    }

    void DisableInteractables()
    {
        foreach(GameObject interact in interatables)
        {
           var stats = interact.GetComponent<IInteractionStats>();
            if(stats != null)
            {
                SetObjectActive(stats, false);
            }
        }
        var stat = setInactiveObject.GetComponent<IInteractionStats>();
        if (stat != null)
        {
            SetObjectActive(stat, true);
        }

    }

    void SetObjectActive(IInteractionStats stats, bool isActive)
    {
        stats.CanInteract = isActive;
    }
}
