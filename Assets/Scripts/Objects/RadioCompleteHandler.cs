using System.Collections.Generic;
using UnityEngine;
using System;

public class RadioCompleteHandler : HandleInteractionBase, ICompleteGame
{
    public RadioCompletionListSO radio;
    INamePlate namePlate => GetComponent<INamePlate>();
    IInteractionStats stats => GetComponent<IInteractionStats>();
    bool isRadiosCleared = false;
    int numbersLeft = 0;
    GameObject mainCamera;

    public event Action OnComplete = delegate { };

    // Start is called before the first frame update
    protected override void Start()
    {
        mainCamera = FindObjectOfType<Camera>().gameObject;
        base.Start();
    }

    protected override void HandleInteract()
    {
        if (radio.HasWon())
        {
            isRadiosCleared = true;
            OnComplete();
            base.HandleInteract();
        }
        else
        {
            namePlate.ChangeNamePlate("Fix " + numbersLeft + " More Radios");
        }
        base.HandleInteract();
    }

    int NumberOfRadiosLeft()
    {
        int count = 0;
        foreach (KeyValuePair<RadioSO, bool> complete in radio.radioStatuses)
        {
            if (complete.Value == false)
            {
                count++;
            }
        }
        return count;
    }

    void Update()
    {
        if (stats != null && stats.IsHovering)
        {
            numbersLeft = NumberOfRadiosLeft();
            if (numbersLeft > 0)
            {
                namePlate.ChangeNamePlate("Fix " + numbersLeft + " More Radios");
            }
            else
            {
                namePlate.ChangeNamePlate("Call For Help");
            }

        }
    }
}
