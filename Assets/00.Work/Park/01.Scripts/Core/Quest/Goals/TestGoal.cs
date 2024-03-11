using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestGoal : Goal
{
    public override void Init(Quest owner)
    {
        base.Init(owner);
        Description = "R키를 누르세요.";
        GoalName = "시작은 간단하게";
    }

    public override void Update()
    {
        if (Completed) return;
        Debug.Log("Q");
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Owner.NextGoal();
        }
    }
}