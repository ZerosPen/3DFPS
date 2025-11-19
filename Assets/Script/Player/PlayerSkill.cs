using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [Header("Skill Player")]
    public SkillSO currentSkill;
    public UltimateSO currentUltimate;

    private InputManager _inputManager;
    private Character _owner;

    private void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _owner = GetComponent<Character>();
    }

    private void Update()
    {
        if (_inputManager.onFoot.Skill1.triggered)
        {
            if (currentSkill == null || CoolDownManager.instance.GetCoolDownSkill() > 0)
            {
                Debug.Log("Using Skill");
                return;
            }

            UseSkill();
        }
        if (_inputManager.onFoot.Ultimate.triggered)
        {
            if (currentUltimate == null || CoolDownManager.instance.GetCoolDownUltimate() > 0 || UltimateManager.instance.GetIsUltimateActive())
            {
                Debug.Log("Using Ulti");
                return;
            }

            UltimateManager.instance.ActivateUltimate(currentUltimate.ultimateCooldown, currentUltimate.ultimateDuration);
        }
    }

    void UseSkill()
    {
        ISkillBehavior behavior = CreateBehavior(currentSkill.behaviourType);

        Character target = _owner;

        StartCoroutine(behavior.Execute(_owner, target, currentSkill));
    }

    private ISkillBehavior CreateBehavior(SkillBehaviourType behaviourType)
    {
        switch (behaviourType)
        {
            case SkillBehaviourType.Heal:
                return new HealingBehavior();
            default:
                return null;
        }
    }
}
