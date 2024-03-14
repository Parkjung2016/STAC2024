using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerSkill
{
    Dash = 1,
    EnemyAttract,
    Encroachment,
}

public class SkillManager : MonoSingleton<SkillManager>
{
    private Dictionary<Type, Skill> _skills;
    private Dictionary<PlayerSkill, Type> _skillTypeDictionary;
    public Skill PreParedSkill { get; set; }
    private float _currentResetFusionTime;
    [SerializeField] private float _resetFusionTime;

    private void Awake()
    {
        _skills = new Dictionary<Type, Skill>();
        _skillTypeDictionary = new Dictionary<PlayerSkill, Type>();

        foreach (PlayerSkill skill in Enum.GetValues(typeof(PlayerSkill)))
        {
            Skill skillComponent = GetComponent($"{skill}Skill") as Skill;
            Type type = skillComponent.GetType();
            _skills.Add(type, skillComponent);
            _skillTypeDictionary.Add(skill, type);
        }
    }

    public T GetSkill<T>() where T : Skill
    {
        Type t = typeof(T);
        if (_skills.TryGetValue(t, out Skill target))
        {
            return target as T;
        }

        return null;
    }

    private void Update()
    {
        if (PreParedSkill)
        {
            if (_currentResetFusionTime >= _resetFusionTime)
            {
                _currentResetFusionTime = 0;
                PreParedSkill = null;
            }
            else _currentResetFusionTime += Time.deltaTime;
        }
        
    }

    //Enum타입으로 그냥 스킬 가져오는 방법.
    public Skill GetSkill(PlayerSkill skill)
    {
        Type type = _skillTypeDictionary[skill];
        if (_skills.TryGetValue(type, out Skill target))
        {
            return target;
        }

        return null;
    }

    public void UseSkillFeedback(PlayerSkill skillType)
    {
    }

    public void PrepareSkill(PlayerSkill skill)
    {
        if (PreParedSkill != null)
        {
            FuseSkill(skill);
        }
        else
        {
            PreParedSkill = GetSkill(skill);
        }
    }

    public Skill FuseSkill(PlayerSkill skill)
    {
        PlayerSkill fusedSkill = PreParedSkill.GetFuseSkill(skill);
        return GetSkill(fusedSkill);
    }
}