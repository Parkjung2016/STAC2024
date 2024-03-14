using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    private const float _groundFlyTime = 0.3f;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player,
        stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.JumpEvent += OnHandleJump;
        _player.PlayerInput.AttackEvent += OnHandleAttack;
        _player.PlayerInput.InteractionEvent += OnHandleInteraction;
        _player.PlayerInput.Skill1Event += OnHandleSkill1;
        _player.PlayerInput.Skill2Event += OnHandleSkill2;
        _player.PlayerInput.Skill3Event += OnHandleSkill3;
    }

    private void OnHandleSkill1()
    {
        SkillManager.Instance.PrepareSkill(PlayerSkill.EnemyAttract);
    }

    private void OnHandleSkill2()
    {
        SkillManager.Instance.PrepareSkill(PlayerSkill.Encroachment);
    }

    private void OnHandleSkill3()
    {
    }

    private void OnHandleInteraction()
    {
        IInteract interact = _player.IsInteractObjectDetected();
        if (interact != null)
        {
            interact.Interact();
            _player.StateMachine.ChangeState(StateEnum.Interact);
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!_player.IsGroundDetected())
        {
            _stateMachine.ChangeState(StateEnum.Fall);
        }
    }

    public override void Exit()
    {
        _player.PlayerInput.JumpEvent -= OnHandleJump;
        _player.PlayerInput.AttackEvent -= OnHandleAttack;
        _player.PlayerInput.Skill1Event -= OnHandleSkill1;
        _player.PlayerInput.Skill2Event -= OnHandleSkill2;
        _player.PlayerInput.Skill3Event -= OnHandleSkill3;
        base.Exit();
    }

    private void OnHandleAttack()
    {
        _stateMachine.ChangeState(StateEnum.PrimaryAttack);
    }

    private void OnHandleJump()
    {
        //땅위에 있을 때만 점프를 한다.
        if (_player.IsGroundDetected())
        {
            _stateMachine.ChangeState(StateEnum.Jump);
        }
    }
}