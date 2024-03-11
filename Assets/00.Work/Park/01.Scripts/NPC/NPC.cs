using System;
using System.Collections;
using System.Collections.Generic;
using cherrydev;
using UnityEngine;

public class NPC : MonoBehaviour, IInteract
{
    [SerializeField] private NPCDataSO _data;

    public void Interact()
    {
        GameManager.Instance.DialogBehaviour.StartDialog(_data.DialogNodeGraph);
    }
}