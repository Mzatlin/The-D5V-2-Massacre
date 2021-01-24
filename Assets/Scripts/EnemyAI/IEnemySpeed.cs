interface IEnemySpeed
{
    void ResetSpeedToBase();
    void SetSpeed(float speed);
    float ObjectSpeed { get; }
}