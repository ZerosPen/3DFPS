using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.GridLayoutGroup;

public class HealingBehavior : ISkillBehavior
{
    public IEnumerator Execute(Character owner, Character target, SkillSO data)
    {
        if (data.durationHeal <= 0)
        {
            InstantHeal(owner, target, data);
        }
        else
        {
            yield return HealOverTime(owner, target, data);
        }
    }

    private void InstantHeal(Character owner, Character target, SkillSO data)
    {
        if (target._healthPoint < target._maxHealthPoint)
        {
            target.RestoreHealth(data.amountHeal);
            Debug.Log($"{owner.name} instantly healed {target.name} by {data.amountHeal}");
        }
    }

    private IEnumerator HealOverTime(Character owner, Character target, SkillSO data)
    {
        float timer = 0f;
        float duration = data.durationHeal;
        float interval = 1f; // 1 second tick

        while (timer < duration)
        {
            if (target._healthPoint < target._maxHealthPoint)
            {
                target.RestoreHealth(data.amountHeal);
                Debug.Log($"{owner.name} heals {target.name} by {data.amountHeal}");
            }
            else
            {
                Debug.Log($"{target.name} already full health");
            }

            timer += interval;
            yield return new WaitForSeconds(interval);
        }

        // Start cooldown when finished
        CoolDownManager.instance.StarCooldownSkill(data.coolDownSkill);
    }
}
