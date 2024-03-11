using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilBattleState : EnemyState<DevilStateEnum>
{
    Player _player;
    int _moveDir;
    float Timer;

    public DevilBattleState(Enemy enemyBase, EnemyStateMachine<DevilStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player = GameManager.Instance.Player;
        SetDirectionPlayer();
    }


    private void SetDirectionPlayer()
    {
        _enemyBase.FlipController(_enemyBase.transform.position.x - _player.transform.position.x);
    }

    public override void UpdateState()
    {
        base.UpdateState();

    }
}
