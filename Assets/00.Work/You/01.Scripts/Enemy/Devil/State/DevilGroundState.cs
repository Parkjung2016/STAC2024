using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DevilGroundState : EnemyState<DevilStateEnum>
{
    Player _player;
    public DevilGroundState(Enemy enemyBase, EnemyStateMachine<DevilStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player = GameManager.Instance.Player;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        RaycastHit2D hit = _enemyBase.IsPlayerDetected();

        float distance = Vector2.Distance(_enemyBase.transform.position, _player.transform.position);

        if (distance < 2 || hit && _enemyBase.IsObstacleInLine(hit.distance))
        {
            _stateMachine.ChangeState(DevilStateEnum.Battle);
            return;
        }
    }
}
