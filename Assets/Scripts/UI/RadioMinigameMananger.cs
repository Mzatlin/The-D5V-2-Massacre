using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioMinigameMananger : HandleInteractionBase
{
    public PlayerStateSO state;
    public Canvas minigameCanvas;
    IInteractionStats interact => GetComponent<IInteractionStats>();
    bool isMiniGameStarted = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        minigameCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMiniGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(DelayToggle());
            }
        }

    }

    protected override void HandleInteract()
    {
        if (state != null && minigameCanvas != null)
        {
            StartCoroutine(DelayToggle());
        }
    }

    void BeginMinigame()
    {

        minigameCanvas.enabled = true;
        isMiniGameStarted = true;
        state.isInteracting = true;
        interact.CanInteract = false;
    }

    void EndMinigame()
    {
        isMiniGameStarted = false;
        minigameCanvas.enabled = false;
        state.isInteracting = false;
        interact.CanInteract = true;
        base.HandleInteract();
    }

    IEnumerator DelayToggle()
    {
        yield return new WaitForSeconds(0.1f);
        if (!isMiniGameStarted)
        {
            BeginMinigame();
        }
        else
        {

            EndMinigame();
        }
    }
}
