using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Quest
{
    public Goal Goal { get; set; }

    public string QuestName { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }

    public void CompleteQuest()
    {
        Completed = true;
            GiveReward();
    }

    public void AddGoal(Goal goal)
    {
        Goal = goal;
        goal.Init(this);
    }

    public void UpdateGoal()
    {
        Goal.Update();
    }

    protected virtual void GiveReward()
    {
    }
}