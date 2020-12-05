using System;

interface IInteractable
{
    event Action OnInteract;
    
    void StartInteraction();
    void StopInteraction();
    void LeaveInteractionRange();
    void EnterInteractionRange();

}