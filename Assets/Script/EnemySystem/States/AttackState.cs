using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private float _moveTimer;
    private float _losePlayerTimer;

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
            _moveTimer = Time.deltaTime;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
