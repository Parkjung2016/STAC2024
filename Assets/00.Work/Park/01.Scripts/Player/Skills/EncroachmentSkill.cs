using System;
using UnityEngine;

public class EncroachmentSkill : Skill
{
    [SerializeField] private GameObject _skillPrefab;

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
                (SkillManager.Instance.GetSkill(PlayerSkill.EnemyAttract) as EnemyAttractSkill).Explosion = true;
                break;
            default:
                fusedSkill = PlayerSkill.Encroachment;
                break;
        }

        return fusedSkill;
    }

    public override void UseSkill()
    {
        base.UseSkill();
        Projectile skill = PoolManager.Instance.Pop(PoolingType.Encroachment) as Projectile;
        skill.Init();
        skill.transform.position = _player.transform.position;
    }
}