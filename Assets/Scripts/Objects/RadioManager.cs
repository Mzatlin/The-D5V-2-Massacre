using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioManager : MonoBehaviour
{
    public RadioCompletionListSO radioSO;
    public RadioKeyExchange radioKey;
    // Start is called before the first frame update
    void Start()
    {
        SetupRadios();
    }

    void SetupRadios()
    {
        radioSO.ResetRadios();
        radioKey.SetRadioKeyExchange();
    }

}
