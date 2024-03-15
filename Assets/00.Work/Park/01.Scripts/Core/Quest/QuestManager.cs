using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuestManager : MonoSingleton<QuestManager>
{
    private Dictionary<string, Quest> _onGoingQuestDictionary = new();
    private Dictionary<string, Quest> _allQuestList = new Dictionary<string, Quest>();

    private void Awake()
    {
        Quest quest = new Quest();
        quest.QuestName = "튜토리얼 진행";
        quest.Description = "튜토리얼은 기초중에 기초이므로 해야한다.";
        Goal goal = new Goal();
        goal.Description = "튜토리얼 NPC와 대화하세요.";
        quest.AddGoal(goal);
        _allQuestList.Add(quest.QuestName, quest);

        quest = new Quest();
        quest.QuestName = "튜토리얼 내용 확인";
        quest.Description = "튜토리얼의 내용은 중요하므로 잘 확인해야한다.";
        goal = new Goal();
        goal.Description = "아무 스킬을 쓰세요.";
        quest.AddGoal(goal);
        _allQuestList.Add(quest.QuestName, quest);
    }

    public void AddQuest(string questName)
    {
        print(_allQuestList.ContainsKey(questName));
        if (!_allQuestList.ContainsKey(questName)) return;
        Quest quest = _allQuestList[questName];
        InventoryUI.Instance.AddQuest(questName, quest.Description, quest.Goal.Description);
        _onGoingQuestDictionary.Add(questName, quest);
    }

    public void RemoveQuest(string questName)
    {
        if (!_onGoingQuestDictionary.ContainsKey(questName)) return;
        _onGoingQuestDictionary.Remove(questName);
        InventoryUI.Instance.RemoveQuest(questName);
    }

    public bool ExistsQuest(string questName)
    {
        return _onGoingQuestDictionary.ContainsKey(questName);
    }

    public void CompleteQuest(string questName)
    {
        _onGoingQuestDictionary[questName].CompleteQuest();
        RemoveQuest(questName);
    }

    private void Update()
    {
        foreach (var quest in _onGoingQuestDictionary)
        {
            quest.Value.UpdateGoal();
        }
    }
}