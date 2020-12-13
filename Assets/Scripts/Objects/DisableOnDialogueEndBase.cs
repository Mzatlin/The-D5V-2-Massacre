using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnDialogueEndBase : MonoBehaviour
{
    IEndDialogue End => GetComponent<IEndDialogue>();
    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (End != null)
        {
            End.OnEndDialogue += HandleEnd;
        }
    }

    void OnDestroy()
    {
        if (End != null)
        {
            End.OnEndDialogue -= HandleEnd;
        }
    }

    protected virtual void HandleEnd()
    {
        gameObject.SetActive(false);
    }
}
