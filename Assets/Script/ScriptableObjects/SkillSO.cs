using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SkillType
{
    damage,
    buff,
    heal
}

[System.Serializable]
public enum SkillBehaviourType
{
    Heal,
    Damage,
    Dash,
    Shield
}

[CreateAssetMenu(menuName = ("SkillSO"))]
public class SkillSO : ScriptableObject
{
    [Header("Description Skill")]
    public string skillName;
    public SkillType skillType;
    public float coolDownSkill;

    public SkillBehaviourType behaviourType;

    //healing skill
    public float amountHeal;
    public float durationHeal;
}
