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
    //This ensures no completed radio carries over to a game restart 
    public void ResetRadios()
    {
        radioStatuses.Clear();
        foreach (RadioSO radio in radios)
        {
            radioStatuses.Add(radio, false);
        }
        completeCount = 0;
    }
    //Sends the location of the radio to a reciever that needs to know the current radio's location
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
    //Returns a boolean that checks if all the radios in the list have been completed
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
