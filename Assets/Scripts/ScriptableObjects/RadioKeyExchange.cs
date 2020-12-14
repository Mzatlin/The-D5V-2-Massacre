using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Lists/KeyRadioExchange")]
public class RadioKeyExchange : ScriptableObject
{
    public List<string> keys = new List<string>();
    public List<int> radioAmount = new List<int>();
    public Dictionary<int, string> radioKeyExchange = new Dictionary<int, string>();

    public void SetRadioKeyExchange()
    {
        if(keys.Count == radioAmount.Count)
        {
            for (int i = 0; i < radioAmount.Count; i++)
            {
                if (!radioKeyExchange.ContainsKey(radioAmount[i]))
                {
                    radioKeyExchange.Add(radioAmount[i], keys[i]);
                }
            }
        }
        else
        {
            Debug.Log("Both lists must be the same size to be initialized properly");
        }

    }


}
