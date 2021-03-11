internal interface ICameraShake
{
    bool IsShaking { get; }
    void TryShake(float duration, float magnitude);
    void ResetShake();
}