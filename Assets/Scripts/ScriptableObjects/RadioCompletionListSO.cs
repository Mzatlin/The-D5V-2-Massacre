using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Lists/Radios")]
public class RadioCompletionListSO : ScriptableObject
{
    public event Action<GameObject> OnRadioComplete;

    public List<GameObject> radios = new List<GameObject>();
    public Dictionary<GameObject,bool> radioStatuses = new Dictionary<GameObject,bool>();
    
    // Start is called before the first frame update
    void ResetRadios()
    {
        radioStatuses.Clear();
        foreach (GameObject radio in radios)
        {
           radioStatuses.Add(radio, false);
        }
    }

    void LogRadio()
    {

    }
    
}
