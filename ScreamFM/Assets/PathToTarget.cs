using UnityEngine;
using Pathfinding;


public class PathToTarget : PathingBase, IEnemyDirection
{
    public Vector2 Direction => direction;

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