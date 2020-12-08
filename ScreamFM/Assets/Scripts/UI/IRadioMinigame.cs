using System;
interface IRadioMinigame
{
    event Action OnMinigameStart;
    event Action OnExit;
    event Action OnComplete;
    void ProcessSuccess();
}