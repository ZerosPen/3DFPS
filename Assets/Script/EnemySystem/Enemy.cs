using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject DebugObject;

    [SerializeField]
    private string currentState;
    public Transform pathsParent;
    public Waypoint path;
    [SerializeField] private GameObject _player;
    public GameObject player { get => _player; }
    public Vector3 lastKnowPos { get => _lastKnowPos; set => _lastKnowPos = value; }
    public EnemyAnimator enemyAnimator { get => _enemyAnimator; set => _enemyAnimator = value; }
    public bool hasLastKnowPos;
    public float sightDistance;
    public float fielddOfView;
    public float eyeHeight;

    [Header("Gun")]
    public Weapon enemyWeapon;
    public int maxAmmo;
    public int currentAmmo;
    [Range(0.1f, 10f)]
    public float fireRate;

    private Vector3 _lastKnowPos;
    private StateMachine _stateMachine;
    private NavMeshAgent agent;
    private EnemyHealth _enemyHealth;
    public EnemyAnimator _enemyAnimator;

    public NavMeshAgent Agent { get => agent; }

    [Header("Events")]
    public OnEnemyDeathEventSO OnEnemyDeathEvent;

    private void Start()
    {
        _stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        _stateMachine.Initialized();
        _player = GameObject.FindGameObjectWithTag("Player");
        _enemyAnimator = GetComponent<EnemyAnimator>();

        currentAmmo = maxAmmo = enemyWeapon.weaponData.ammoCapacity;

        pathsParent = GameObject.FindGameObjectWithTag("Path").GetComponent<Transform>();
        PickRandomPath();
    }

    private void Update()
    {
        if (_enemyHealth != null && !_enemyHealth.GetisEnemyDeath())
        {
            CanSeePlayer();
            currentState = _stateMachine.activeState.ToString();
        }
    }

    public void EnemyDeath()
    {
        agent.SetDestination(transform.position);
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

    void PickRandomPath()
    {
        if (pathsParent == null || pathsParent.childCount == 0)
        {
            Debug.LogWarning("No paths assigned!");
            return;
        }

        int randomIndex = Random.Range(0, pathsParent.childCount);
        Transform selectedPath = pathsParent.GetChild(randomIndex);

        path = selectedPath.GetComponent<Waypoint>();

        if (path == null)
            Debug.LogWarning("Selected path has no Waypoint script!");

        Debug.Log("Enemy picked path: " + selectedPath.name);
    }

    public void ReloadWeapon()
    {
        StartCoroutine(ReloadingWeapon());
    }

    IEnumerator ReloadingWeapon()
    {
        yield return new WaitForSeconds(enemyWeapon.weaponData.reloadTime);
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        OnEnemyDeathEvent.OnEnemyDeathEvent += EnemyDeath;
    }

    private void OnDestroy()
    {
        OnEnemyDeathEvent.OnEnemyDeathEvent -= EnemyDeath;
    }
}
