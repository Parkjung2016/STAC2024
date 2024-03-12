using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilDeadState : EnemyState<DevilStateEnum>
{
    public DevilDeadState(Enemy enemyBase, EnemyStateMachine<DevilStateEnum> stateMachine, string animBoolName) : base(enemyBase, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemyBase.isDead = true;
        float deadFadeDelay = 3f;
        _enemyBase.StartDelayCallback(deadFadeDelay, () =>
        {
            _rigidbody.gravityScale = 0;
            _enemyBase.Collider.enabled = false;
            GameObject.Destroy(_enemyBase.gameObject);
            //_enemyBase.SpriteReneererCompo.DOFade(0, 1).OnComplete(() =>
            //{
            //    GameObject.Destroy(_enemyBase.gameObject);
            //});
        });
    }
}
