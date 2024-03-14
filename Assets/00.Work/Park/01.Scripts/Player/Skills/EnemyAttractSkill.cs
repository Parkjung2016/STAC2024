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
        }

        return fusedSkill;
    }

    public override void UseSkill()
    {
        base.UseSkill();
        Transform trm = PoolManager.Instance.Pop(PoolingType.EnemyAttract).transform;
        trm.position = _player.transform.position;
    }
}