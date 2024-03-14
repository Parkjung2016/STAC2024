using System;

public class EncroachmentSkill : Skill
{
    private void OnValidate()
    {
        _skillType = PlayerSkill.Encroachment;
    }

    public override PlayerSkill GetFuseSkill(PlayerSkill skill)
    {
        PlayerSkill fusedSkill = PlayerSkill.Dash;
        switch (skill)
        {
            case PlayerSkill.EnemyAttract:
                fusedSkill = PlayerSkill.EnemyAttract;
                break;
        }

        return fusedSkill;
    }
}