using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Character
{
    private CharacterDataSO _characterData;
    private EnemyUI _enemyUI;
    private EnemyAnimator _enemyAnimator;
   [SerializeField] private bool isEnemyDeath;

    [Header("Events")]
    public OnEnemyDeathEventSO OnEnemyDeath;

    private void Start()
    {
        _characterData = GetComponent<EnemyData>().CharacterData;
        _healthPoint = _maxHealthPoint = _characterData.healthCharacter;
        _enemyUI = GetComponent<EnemyUI>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void Update()
    {
        _healthPoint = Mathf.Clamp(_healthPoint, 0, _maxHealthPoint);
        _enemyUI.UpdateHealthUI(_healthPoint, _maxHealthPoint);
    }

    public override void TakeDamage(float damage)
    {
        _healthPoint -= damage;
        if (_healthPoint <= 0 && !isEnemyDeath)
        {
            isEnemyDeath = true;
            ScoreManager.instance.AddScore(100);
            StatusManager.instance.UpdatekilledEnemyStatus();
            SoundManager.instance.Play2DSound("Death");
            _enemyAnimator.PlayDeathAnimation();
            OnEnemyDeath.EnemyDeath();
            StartCoroutine(DelayDestroyEnemy());
        }
    }

    public bool GetisEnemyDeath()
    {
        return isEnemyDeath;
    }

    public override void RestoreHealth(float healAmount)
    {
        _healthPoint += healAmount;
    }
    
    IEnumerator DelayDestroyEnemy()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
