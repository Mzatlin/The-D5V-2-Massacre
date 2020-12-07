using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheckerController : MonoBehaviour, ICheckKey
{
    public string keyName;
    public string KeyName => keyName;
    public KeyListSO keys;
    public KeyListSO Keys => keys;
}
