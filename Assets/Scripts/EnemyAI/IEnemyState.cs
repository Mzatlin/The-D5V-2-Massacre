using System;
interface IEnemyState
{
    EnemyStateBase CurrentState { get; }

    event Action<EnemyStateBase> OnStateChanged;
}