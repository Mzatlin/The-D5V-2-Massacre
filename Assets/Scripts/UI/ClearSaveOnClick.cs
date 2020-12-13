using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSaveOnClick : MonoBehaviour
{
    public SaveStateSO save;
    public void ClearSave()
    {
        save.IsOpeningComplete = false;
    }
}
