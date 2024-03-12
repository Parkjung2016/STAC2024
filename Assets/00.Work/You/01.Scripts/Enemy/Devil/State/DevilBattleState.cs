using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class DevilBattleState : EnemyState<DevilStateEnum>
{
    Player _player;
    int _moveDir;
    float _timer;

    private readonly int _xVelocityHash = Animator.StringToHash("x_Velocity");

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
        _enemyBase.FlipController(_player.transform.position.x- _enemyBase.transform.position.x);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _enemyBase.AnimatorCompo.SetFloat(_xVelocityHash, Mathf.Abs(_rigidbody.velocity.x));

        _moveDir = _enemyBase.FacingDirection;
        _enemyBase.SetVelocity(_enemyBase.moveSpeed * _moveDir, _rigidbody.velocity.y);

        RaycastHit2D hit = _enemyBase.IsPlayerDetected();

        if(hit && !_enemyBase.IsObstacleInLine(hit.distance))
        {
            _timer = _enemyBase.battleTime;
            
            if(hit.distance < _enemyBase.attackDistance && CanAttack())
            {
                int a = Random.Range(0, 2);
                if(a == 0)
                {
                _stateMachine.ChangeState(DevilStateEnum.Attack);

                }
                else
                {
                _stateMachine.ChangeState(DevilStateEnum.Breathe);

                }
                return;
            }
        }

        float distance = Vector2.Distance(_player.transform.position, _enemyBase.transform.position);
        if (!_enemyBase.IsGroundDetected() || (distance < _enemyBase.attackDistance))
        {
            _enemyBase.StopImmediately(false);
            return;
        }

        if (_timer >= 0 && distance < _enemyBase.runAwayDistance)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _stateMachine.ChangeState(DevilStateEnum.Idle);
        }
    }

    private bool CanAttack()
    {
        return Time.time >= _enemyBase.lastTimeAttacked + _enemyBase.attackCooldown;
    }
}
