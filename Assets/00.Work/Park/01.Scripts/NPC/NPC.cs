using System;
using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class NPC : MonoBehaviour, IInteract
{
    private NPCConversation _conversation;
    [SerializeField] private NPCDataSO _data;


    private void Awake()
    {
        _conversation = GetComponent<NPCConversation>();
    }

    public void Interact()
    {
        ConversationManager.Instance.StartConversation(_conversation);
    }

    public void GiveQuest(string questName)
    {
        QuestManager.Instance.AddQuest(questName);
    }

    public void EndDialog()
    {
        GameManager.Instance.Player.StateMachine.ChangeState(StateEnum.Idle);
    }
}