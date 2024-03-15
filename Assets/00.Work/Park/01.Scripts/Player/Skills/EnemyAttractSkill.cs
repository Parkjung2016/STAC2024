using UnityEngine;

public class EnemyAttractSkill : Skill
{
    [SerializeField] private GameObject _skillPrefab;
    public bool Explosion { get; set; }

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
                Explosion = true;
                break;
            default:
                fusedSkill = PlayerSkill.EnemyAttract;
                break;
        }

        return fusedSkill;
    }

    public override void UseSkill()
    {
        base.UseSkill();
        PlayerCatchSkill skill = PoolManager.Instance.Pop(PoolingType.EnemyAttract) as PlayerCatchSkill;
        skill.transform.position = _player.transform.position;
        skill.transform.rotation = _player.transform.rotation;
        skill.Init();
    }
}