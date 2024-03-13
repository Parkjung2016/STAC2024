using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilHitState : EnemyState<DevilStateEnum>
{
    private readonly int hitHash = Animator.StringToHash("hit");

    public DevilHitState(Enemy enemyBase, EnemyStateMachine<DevilStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemyBase.AnimatorCompo.Play(hitHash, -1, 0);
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
