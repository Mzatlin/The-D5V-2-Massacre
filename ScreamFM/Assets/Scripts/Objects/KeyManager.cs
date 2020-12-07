using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField]
    KeyListSO keys;
    // Start is called before the first frame update
    void Start()
    {
        if(keys != null)
        {
            keys.ResetKeys();
        }
        else
        {
            Debug.Log("No KeyList assigned in KeyManager!");
        }
    }

}
