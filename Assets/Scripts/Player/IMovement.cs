interface IMovement
{
    float MoveSpeed { get; set; }
    void ApplyMovement(float xDirection);
}