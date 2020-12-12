using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Lists/Radios")]
public class RadioCompletionListSO : ScriptableObject
{
    public event Action<Transform> OnRadioComplete = delegate { };
    public int completeCount = 0;
    public List<RadioSO> radios = new List<RadioSO>();
    public Dictionary<RadioSO, bool> radioStatuses = new Dictionary<RadioSO, bool>();

    public void ResetRadios()
    {
        radioStatuses.Clear();
        foreach (RadioSO radio in radios)
        {
            radioStatuses.Add(radio, false);
        }
        completeCount = 0;
    }

    public void LogRadio(RadioSO radio, Transform radioTransform)
    {
        if (radio != null && radioStatuses.ContainsKey(radio))
        {
            completeCount++;
            radioStatuses[radio] = true;
            OnRadioComplete?.Invoke(radioTransform);
        }
        else
        {
            Debug.Log("Radio does not exist!");
        }
    }

    public bool HasWon()
    {
        foreach(KeyValuePair<RadioSO,bool> radio in radioStatuses)
        {
            if (radio.Value == false)
            {
                return false;
            }
        }
        return true;
    }

}
