using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Quest
{
    private List<Goal> _goals = new();

    public Goal CurrentGoal { get; set; }
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperiencedReward { get; set; }
    public int ItemReward { get; set; }
    public bool Completed { get; set; }

    public bool CheckQuest()
    {
        Completed = _goals.All(x => x.Completed);
        if (Completed)
        {
            GiveReward();
        }

        return Completed;
    }

    public void AddGoal(Goal goal)
    {
        if (CurrentGoal == null) CurrentGoal = goal;
        _goals.Add(goal);
        goal.Init(this);
    }

    public void UpdateGoal()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            _goals[i].Update();
        }
    }

    public void NextGoal()
    {
        CurrentGoal.Complete();
        if (!CheckQuest())
        {
            int idx = _goals.IndexOf(CurrentGoal);
            _goals[idx + 1].Complete();
        }
    }

    private void GiveReward()
    {
        Debug.Log("끝");
    }
}