using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UAPT.Utile;

public struct QuestValue
{
    public string name;
    public string info;
    public string goal;
}

public class InventoryUI : MonoSingleton<InventoryUI>
{
    private UIDocument _doc;
    [SerializeField] private VisualTreeAsset _questTemplate;
    [SerializeField] private InputReader _inputReader;
    private Dictionary<string, Button> _questDictionary = new();
    private Label _questTitleLabel, _questInfoLabel, _questGoalLabel;


    private bool _opened;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        questInit();

        var root = _doc.rootVisualElement;
        var btnRoot = root.Q<VisualElement>("inventory_bottom_contain-box");

        Button profileBtn = btnRoot.Q<Button>("profil_tabbar-button");
        Button inventoryBtn = btnRoot.Q<Button>("quest_tabbar-button");

        VisualElement profilePage = root.Q<VisualElement>("profil_page_contain-box");
        VisualElement inventoryPage = root.Q<VisualElement>("quest_page_contain-box");

        ToolKitUtile.SetClikeEvent(profileBtn, () =>
        {
            profilePage.RemoveFromClassList("on");
            inventoryPage.AddToClassList("on");
            Debug.Log("dd");
        });
        ToolKitUtile.SetClikeEvent(inventoryBtn, () =>
        {
            inventoryPage.RemoveFromClassList("on");
            profilePage.AddToClassList("on");
        });
    }

    private void OnEnable()
    {
        _inputReader.OpenMenuEvent += HandleOpenMenuEvent;
    }

    private void HandleOpenMenuEvent()
    {
        _opened = !_opened;
        OnUI(_opened);
    }

    public void OnUI(bool OnGUI)
    {
        var root = _doc.rootVisualElement;
        var screen = root.Q<VisualElement>("screen_contain-box");
        if (OnGUI)
            screen.AddToClassList("on");
        else
            screen.RemoveFromClassList("on");
    }


    private void questInit()
    {
        var root = _doc.rootVisualElement;
        var questRoot = root.Q<VisualElement>("quest_page_contain-box");
        _questTitleLabel = questRoot.Q<Label>("stat_hp-label");
        _questInfoLabel = questRoot.Q<Label>("quest_info-label");
        _questGoalLabel = questRoot.Q<Label>("quest_goals-label");
    }

    public void AddQuest(string questName, string questInfo, string questGoal)
    {
        QuestValue quest;
        quest.name = questName;
        quest.info = questInfo;
        quest.goal = questGoal;

        var root = _doc.rootVisualElement;
        var questRoot = root.Q<VisualElement>("quest_page_contain-box");
        var questScroll = root.Q<ScrollView>("quest-scroll");
        var questInfoTemplate = _questTemplate.Instantiate().Q<Button>();
        questInfoTemplate.text = questName;
        questInfoTemplate.RegisterCallback<ClickEvent>(evt =>
        {
            _questTitleLabel.text = quest.name;
            _questInfoLabel.text = quest.info;
            _questGoalLabel.text = quest.goal;
        });

        questScroll.Add(questInfoTemplate);
        _questDictionary.Add(questName, questInfoTemplate);
    }

    public void RemoveQuest(string questName)
    {
        print(_questDictionary[questName]);
        if (!_questDictionary.ContainsKey(questName)) return;
        var root = _doc.rootVisualElement;

        var questScroll = root.Q<ScrollView>("quest-scroll");
        questScroll.Remove(_questDictionary[questName]);
    }
}