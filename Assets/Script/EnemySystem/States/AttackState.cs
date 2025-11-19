using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private float _moveTimer;
    private float _losePlayerTimer;
    private float _shotTimer;

    public override void Enter()
    {
  
    }

    public override void Exit()
    {

    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            _losePlayerTimer = 0; 
            _moveTimer += Time.deltaTime;
            _shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.player.transform);

            if (_shotTimer > enemy.fireRate)
            {
                Shoot();
            }

            if (_moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                _moveTimer = 0;
    
            }
        }
        else
        {
            _losePlayerTimer += Time.deltaTime;
            if (_losePlayerTimer > 0)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    void Shoot()
    {
        if (enemy.currentAmmo > 0)
        {
            enemy.enemyWeapon.EnemyAttack();
            enemy.currentAmmo--;
            _shotTimer = 0;
            Debug.Log("FIRE!");
        }
        else
        {
            enemy.ReloadWeapon();
        }
    }
}
