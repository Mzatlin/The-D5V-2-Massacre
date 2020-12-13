interface IClimb
{
    bool IsClimbing { get; }
    void SetClimbSpeed(float newSpeedMultiplier);
    void ResetClimbSpeed();
}