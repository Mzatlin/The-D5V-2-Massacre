using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNamePlateByKey : MonoBehaviour
{
    public string changedMessage;
    ICheckKey keyChecker;
    INamePlate namePlate;
    IInteractionStats stats;
    // Start is called before the first frame update
    void Start()
    {
        namePlate = GetComponent<INamePlate>();
        stats = GetComponent<IInteractionStats>();
        keyChecker = GetComponent<ICheckKey>();
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
        if(keyChecker != null)
        {
            if(keyChecker.Keys != null && keyChecker.Keys.IsKeyCollected(keyChecker.KeyName))
            {
                namePlate.ChangeNamePlate(changedMessage);
            }
        }
    }
}
