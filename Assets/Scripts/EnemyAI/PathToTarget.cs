using UnityEngine;
using Pathfinding;


public class PathToTarget : PathingBase, IEnemyDirection, IEnemyPath
{
    public Vector2 Direction => direction;//pathDirectionOfCurrentPoint;
    public bool IsPathing => CanPath;
    public bool CanPath { get; set; } = true;
    float stoppingDistance = 1f;

    public void SetPathTarget(Transform nextTarget)
    {
        target = nextTarget;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void FixedUpdate()
    {
        if (path != null && CanPath)
        {
            CheckPathing();
            MoveSeeker();
            UpdateWayPoint();
        }
    }






}