using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SaveState")]
public class SaveStateSO : ScriptableObject
{
    public bool IsOpeningComplete = false;

    public void ClearSave()
    {
       IsOpeningComplete = false;
    }
}
