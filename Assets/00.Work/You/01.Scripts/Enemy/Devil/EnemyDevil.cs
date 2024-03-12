using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DevilStateEnum
{
    Idle,
    Move,
    Battle,
    Attack,
    //Fire,
    Dead,
    Hit,
    Breathe
}

public class EnemyDevil : Enemy
{
    public EnemyStateMachine<DevilStateEnum> StateMachine { get;private set; }

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine<DevilStateEnum>();

        foreach(DevilStateEnum state in Enum.GetValues(typeof(DevilStateEnum)))
        {
            string typeName = state.ToString();
            Type t = Type.GetType($"Devil{typeName}State");

            if(t != null)
            {
                var enemyState = Activator.CreateInstance(t, this, StateMachine, typeName) as EnemyState<DevilStateEnum>;
                StateMachine.AddState(state, enemyState);
            }
            else
            {
                Debug.Log(typeName);
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        StateMachine.Initialize(DevilStateEnum.Idle, this);
    }

    protected override void Update()
    {
        base.Update();

        StateMachine.CurrentState.UpdateState();
    }

    public override void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    protected override void HandleDie(Vector2 direction)
    {
        StateMachine.ChangeState(DevilStateEnum.Dead);
    }

}
