using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RadioUIUpdateController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public RadioCompletionListSO radioCount;

    // Start is called before the first frame update
    void Start()
    {

        if (radioCount != null)
        {
            radioCount.OnRadioComplete += UpdateCountOnComplete;
        }
        countText.text = "0/5";
    }

    private void OnDestroy()
    {
        if (radioCount != null)
        {
            radioCount.OnRadioComplete -= UpdateCountOnComplete;
        }
    }

    private void UpdateCountOnComplete(Transform obj)
    {
        countText.text = radioCount.completeCount + "/5";
    }
}
