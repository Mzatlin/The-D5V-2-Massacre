using UnityEngine;
using Pathfinding;


public class PathToTarget : PathingBase, IEnemyDirection, IEnemyPath
{
    public Vector2 Direction => direction;
    private bool canPath;
    public bool CanPath { get => canPath; set => canPath = value; }

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
        if (path != null)
        {
            CheckPathing();
            MoveSeeker();
            UpdateWayPoint();
        }
    }






}