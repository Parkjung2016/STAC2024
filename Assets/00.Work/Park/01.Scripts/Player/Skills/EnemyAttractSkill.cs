public class EnemyAttractSkill : Skill
{
    private void OnValidate()
    {
        _skillType = PlayerSkill.EnemyAttract;
    }

    public override PlayerSkill GetFuseSkill(PlayerSkill skill)
    {
        PlayerSkill fusedSkill = PlayerSkill.Dash;
        switch (skill)
        {
            case PlayerSkill.Encroachment:
                fusedSkill = PlayerSkill.EnemyAttract;
                break;
        }

        return fusedSkill;
    }
}