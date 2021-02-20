using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWriterOnAwake : MonoBehaviour
{
    public DialogueWriterSO dialogueWriter;
    // Start is called before the first frame update
    void Awake()
    {
        if(dialogueWriter != null)
        {
            dialogueWriter.ResetWriter();
        }
        else
        {
            Debug.Log(gameObject.name + " has a resetwriteronawake without the dialogueSO!");
        }
    }

}
