using System;
using UnityEngine;

public abstract class EnemyStateBase
{
    protected GameObject gameObjectEnemy;
    protected Transform transformEnemy;

    public abstract Type Tick();
    public abstract void BeginState();

    public EnemyStateBase(GameObject gameObject)
    {
        gameObjectEnemy = gameObject;
        transformEnemy = gameObject.transform;
    }
}
