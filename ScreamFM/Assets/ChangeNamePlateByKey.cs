using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNamePlateByKey : MonoBehaviour
{
    public KeyListSO keys;
    public string changedMessage;
    public string keyName;
    INamePlate namePlate;
    IInteractionStats stats;
    // Start is called before the first frame update
    void Start()
    {
        namePlate = GetComponent<INamePlate>();
        stats = GetComponent<IInteractionStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats != null && stats.IsHovering)
        {
            ValidateKeys();
        }
    }

    void ValidateKeys()
    {
        if(keys != null && keys.IsKeyCollected(keyName))
        {
            namePlate.ChangeNamePlate(changedMessage);
        }
    }
}
