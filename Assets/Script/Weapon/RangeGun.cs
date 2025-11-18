using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeGun : Weapon
{
    [Header("Config")]
    public GameObject bulletPrefab;
    public Transform bulletContainer;
    public Transform bulletSpawn;
    public float bulletVelocity;


    public override void Attack()
    {
        if (bulletContainer == null || bulletPrefab == null)
        {
            Debug.LogWarning("bulletPrefab or bulletContainer is NULL!");
            return;
        }

        //spawn the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity, bulletContainer);

        SoundManager.instance.Play2DSound("Gun");

        //Shoot the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(bulletSpawn.forward * bulletVelocity, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("RangeGun: Bullet prefab has NO rigidbody!");
        }
    }
}
