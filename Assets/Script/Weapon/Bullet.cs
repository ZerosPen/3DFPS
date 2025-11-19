using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float lifeTimeBullet;
    [SerializeField]
    private float bulletDamage;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<IDamageable>() != null)
                collision.gameObject.GetComponent<IDamageable>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Bullet collide with " + collision.gameObject.name);
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(DelayDestroyAllBullet(lifeTimeBullet));
    }

    IEnumerator DelayDestroyAllBullet(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
