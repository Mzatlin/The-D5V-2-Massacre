using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnInteract : HandleInteractionBase, ICompleteGame
{
    public RadioCompletionListSO radio;
    INamePlate namePlate => GetComponent<INamePlate>();
    IInteractionStats stats => GetComponent<IInteractionStats>();
    public string sceneName;
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
            StartCoroutine(Delay());
            base.HandleInteract();
        }
        else
        {
            namePlate.ChangeNamePlate("Fix "+numbersLeft+" More Radios");
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

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        OnComplete(); 
        //ToDo: Move the load scene into another script - or move the leadup to another script
        AkSoundEngine.PostEvent("StopAll", mainCamera);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
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
