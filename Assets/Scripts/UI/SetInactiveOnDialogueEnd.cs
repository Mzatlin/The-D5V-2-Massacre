using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactiveOnDialogueEnd : MonoBehaviour
{

    IEndDialogue End => GetComponent<IEndDialogue>();
    // Start is called before the first frame update
    void Start()
    {
        if(End != null)
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

    private void HandleEnd()
    {
        gameObject.SetActive(false);
    }

}
