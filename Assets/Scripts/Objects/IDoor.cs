interface IDoor
{
    void OpenDoor();
    void CloseDoor();
    bool IsOpen { get; }
}