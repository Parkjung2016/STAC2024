using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerSkill
{
    Dash = 1,
}

public class SkillManager : MonoSingleton<SkillManager>
{
    private Dictionary<Type, Skill> _skills;
    private Dictionary<PlayerSkill, Type> _skillTypeDictionary;

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
}