using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public LayerMask hitMask;
    public override void PlayerAttack()
    {
        Debug.Log("Get Called");
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * weaponData.rangeMelee, Color.red, 0.2f);

        if (Physics.Raycast(ray, out RaycastHit hit, weaponData.rangeMelee, hitMask))
        {
            IDamageable dmg = hit.collider.GetComponent<IDamageable>();
            if (dmg != null)
            {
                dmg.TakeDamage(weaponData.meleeDamage);
            }
            else
            {
                Debug.Log("Sword hit something but no IDamageable");
            }
        }
        else
        {
            Debug.Log("Sword missed");
        }
    }
}
