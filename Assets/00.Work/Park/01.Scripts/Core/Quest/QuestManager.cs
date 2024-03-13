using System;
using System.Collections.Generic;

public class QuestManager : MonoSingleton<QuestManager>
{
    private Dictionary<string, Quest> _questDictionary = new();

    public void AddQuest(string questName)
    {
        Quest quest = new Quest();
        quest.QuestName = questName;
        TestGoal goal = new TestGoal();
        TestGoal2 goal2 = new TestGoal2();
        quest.AddGoal(goal);
        quest.AddGoal(goal2);
        _questDictionary.Add(questName, quest);
    }

    private void Update()
    {
        foreach (var quest in _questDictionary)
        {
            quest.Value.UpdateGoal();
        }
    }
}