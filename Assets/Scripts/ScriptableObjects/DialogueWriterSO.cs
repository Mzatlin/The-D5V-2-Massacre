using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "DialogueWriter")]
public class DialogueWriterSO : ScriptableObject
{
    public bool IsWriting { get; private set; }

    public void ResetWriter()
    {
        IsWriting = false;
    }

    public void RequestToWrite()
    {
        if (IsWriting)
        {
            return;
        }
        else
        {
            IsWriting = true;
        }
    }

    public void FinishWriting()
    {
        IsWriting = false;
    }

}
