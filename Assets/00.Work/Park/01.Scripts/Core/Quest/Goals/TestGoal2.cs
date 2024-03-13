using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestGoal2 : Goal
{
    public override void Init(Quest owner)
    {
        base.Init(owner);
        Description = "C키를 누르세요.";
        GoalName = "시작은 간단하게";
    }

    public override void Update()
    {
        if (Completed) return;
        Debug.Log("C");
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            Owner.NextGoal();
        }
    }
}