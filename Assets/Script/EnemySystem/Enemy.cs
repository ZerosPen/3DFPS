using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine _stateMachine;
    private NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent; }

    [SerializeField]
    private string currentState;
    public Waypoint path;
    [SerializeField] private GameObject _player;
    public float sightDistance;
    public float fielddOfView;
    public float eyeHeight;

    private void Start()
    {
        _stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        _stateMachine.Initialized();
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        CanSeePlayer();
        currentState = _stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if (_player != null)
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = _player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

                if (angleToPlayer >= -fielddOfView && angleToPlayer <= fielddOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance))
                    {
                        if (hitInfo.transform.gameObject == _player)
                        {
                            return true;
                        }
                    }
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                }
            }
        }
        return false;
    }
}
