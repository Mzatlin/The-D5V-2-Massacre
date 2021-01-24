using UnityEngine;
using Pathfinding;


public class PathToTarget : PathingBase, IEnemyDirection, IEnemyPath, IEnemySpeed
{
    public Vector2 Direction => direction;//pathDirectionOfCurrentPoint;
    public float distance = 0;
    public bool CanPath { get; set; } = true;
    public float ObjectSpeed { get => objectSpeed; set => objectSpeed = value; }

    public bool IsPathing = false;
    float stoppingDistance = 1f;
    float baseSpeed;

    public void SetPathTarget(Transform nextTarget)
    {
        target = nextTarget;
    }

    void LogDistance()
    {
        distance = (Vector2.Distance(target.position, transform.position));
        //Debug.Log(distance);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        InvokeRepeating("UpdatePath", 0f, .5f);
        baseSpeed = objectSpeed;
    }

    void FixedUpdate()
    {
        IsPathing = CanPath;
        if (path != null && CanPath)
        {
            CheckPathing();
            MoveSeeker();
            UpdateWayPoint();
        }
        LogDistance();
    }

    public void ResetSpeedToBase()
    {
        objectSpeed = baseSpeed;
    }

    public void SetSpeed(float _speed)
    {
        objectSpeed += _speed;
    }
}