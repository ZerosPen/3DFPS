using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void PlayAttackAnimation()
    {
        _animator.SetTrigger("attack");
    }

    public void PlayIdleAnimation()
    {
        _animator.SetBool("isIdle", true);
    }

    public void CancelIdleAnimation()
    {
        _animator.SetBool("isIdle", false);

    }

    public void PlayDeathAnimation()
    {
        _animator.SetBool("isDead", true);
    }

    public void PlayWalkAnimation(Transform positionEnemy)
    {
        //_animator.SetFloat("walkingPos", positionEnemy.position);
    }
}
