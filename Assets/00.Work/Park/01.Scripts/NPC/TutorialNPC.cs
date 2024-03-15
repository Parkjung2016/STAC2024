using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNPC : NPC
{
    public override void Interact()
    {
        base.Interact();
        if (QuestManager.Instance.ExistsQuest("튜토리얼 진행"))
        {
            QuestManager.Instance.CompleteQuest("튜토리얼 진행");
        }
    }
}
