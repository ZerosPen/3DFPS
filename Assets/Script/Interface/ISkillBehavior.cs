using System.Collections;

public interface ISkillBehavior
{
    IEnumerator Execute(Character owner, Character target, SkillSO data);
}
