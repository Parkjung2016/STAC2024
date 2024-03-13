using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilMoveState : DevilGroundState
{
    public DevilMoveState(Enemy enemyBase, EnemyStateMachine<DevilStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _enemyBase.SetVelocity(_enemyBase.moveSpeed * _enemyBase.FacingDirection, _enemyBase.RigidbodyCompo.velocity.y);

        if (_enemyBase.IsWallDetected() || !_enemyBase.IsGroundDetected())
        {
            _stateMachine.ChangeState(DevilStateEnum.Idle);
        }
    }
}
