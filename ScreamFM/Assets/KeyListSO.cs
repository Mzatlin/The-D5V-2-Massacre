using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Lists/Keys")]
public class KeyListSO : ScriptableObject
{

    public Dictionary<string,bool> keyStatuses = new Dictionary<string, bool>();
    public List<string> keyNames = new List<string>();

    public void ResetKeys()
    {
        keyStatuses.Clear();
        foreach (string key in keyNames)
        {
          keyStatuses.Add(key, false);
        }

    }

    public bool IsKeyCollected(string key)
    {
        if(keyStatuses[key] == true)
        {
            return true;
        }
        return false;
    }

}
