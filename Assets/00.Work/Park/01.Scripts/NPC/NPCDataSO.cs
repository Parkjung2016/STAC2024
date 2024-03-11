using System.Collections;
using System.Collections.Generic;
using cherrydev;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC Data", menuName = "SO/NPC DataSO")]
public class NPCDataSO : ScriptableObject
{
    public string NpcName;
    public bool CanDialog;

    public DialogNodeGraph DialogNodeGraph;
}