using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RadioMinigameMananger : HandleInteractionBase, IRadioMinigame
{
    public PlayerStateSO state;
    public Canvas minigameCanvas;
    Collider2D radioCollider => GetComponent<Collider2D>();
    IInteractionStats interact => GetComponent<IInteractionStats>();
    bool isMiniGameStarted = false;

    public event Action OnMinigameStart = delegate { };
    public event Action OnExit = delegate { };
    public event Action OnComplete = delegate { };

    [SerializeField] GameObject mainCamera;

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
            if (Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(DelayToggle());
            }
        }

    }

    protected override void HandleInteract()
    {
        if (state != null && minigameCanvas != null && interact.IsInteracting)
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
        OnMinigameStart();
    }

    void EndMinigame()
    {
        AkSoundEngine.PostEvent("Stop_Sines", mainCamera);
        isMiniGameStarted = false;
        minigameCanvas.enabled = false;
        state.isInteracting = false;
        interact.CanInteract = true;
        OnExit();
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

    public void ProcessSuccess()
    {
        OnComplete();
        if(radioCollider != null)
        {
            radioCollider.enabled = false;
        }
        EndMinigame();
    }
}
