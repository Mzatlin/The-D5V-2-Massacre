using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheckerController : MonoBehaviour, ICheckKey
{
    public string keyName;
    public string KeyName => keyName;
    public KeyListSO keys;
    public KeyListSO Keys => keys;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
