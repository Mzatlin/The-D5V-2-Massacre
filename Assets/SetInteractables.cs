using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteractables : MonoBehaviour
{
    [SerializeField]
    List<GameObject> interatables = new List<GameObject>();
    public SaveStateSO save;

    // Start is called before the first frame update
    void Start()
    {
        if(save != null)
        {
            if (!save.IsOpeningComplete)
            {
                DisableInteractables();
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
                stats.CanInteract = false;
            }
        }
    }
}
