using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Lists/Radios")]
public class RadioCompletionListSO : ScriptableObject
{
    public event Action<Transform> OnRadioComplete = delegate { };

    public List<RadioSO> radios = new List<RadioSO>();
    public Dictionary<RadioSO, bool> radioStatuses = new Dictionary<RadioSO, bool>();

    // Start is called before the first frame update
    public void ResetRadios()
    {
        radioStatuses.Clear();
        foreach (RadioSO radio in radios)
        {
            radioStatuses.Add(radio, false);
        }
    }

    public void LogRadio(RadioSO radio, Transform radioTransform)
    {
        if (radio != null && radioStatuses.ContainsKey(radio))
        {
            radioStatuses[radio] = true;
            OnRadioComplete?.Invoke(radioTransform);
        }
        else
        {
            Debug.Log("Radio does not exist!");
        }
    }

}
