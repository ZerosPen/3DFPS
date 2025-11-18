using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable, IHealable
{
    [Header("Health Status")]
    public  float _maxHealthPoint;
    public float _healthPoint { get; set; }

    public abstract void TakeDamage(float damage);
    public abstract void RestoreHealth(float heal);

}
