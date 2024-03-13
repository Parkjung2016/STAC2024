using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBreatheState : EnemyState<DevilStateEnum>
{
    public DevilBreatheState(Enemy enemyBase, EnemyStateMachine<DevilStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemyBase.StopImmediately(false);

    }

    public override void Exit()
    {
        _enemyBase.lastTimeAttacked = Time.time;
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_triggerCalled)
        {
            _stateMachine.ChangeState(DevilStateEnum.Battle);
        }
    }
}
