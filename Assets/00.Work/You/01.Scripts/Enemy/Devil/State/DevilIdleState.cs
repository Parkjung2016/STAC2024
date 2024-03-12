using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilIdleState : DevilGroundState
{
    private Coroutine _delayCorouine = null;
    public DevilIdleState(Enemy enemyBase, EnemyStateMachine<DevilStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if(_delayCorouine != null)
        {
            _enemyBase.StopCoroutine(_delayCorouine);
        }
        _enemyBase.StopImmediately(false);

        _delayCorouine = _enemyBase.StartDelayCallback(_enemyBase.idleTime, () =>
        {
            _stateMachine.ChangeState(DevilStateEnum.Move);
        });
    }

    public override void Exit()
    {
        base.Exit();
        if (_delayCorouine != null)
        {
            _enemyBase.StopCoroutine(_delayCorouine);
        }

        if(_enemyBase.IsWallDetected() || !_enemyBase.IsGroundDetected())
        {
            _enemyBase.Flip();
        }
    }
}
