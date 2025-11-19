using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();

    private PlayerCombat _playerCombat;

    private void Start()
    {
        _playerCombat = GetComponent<PlayerCombat>();

        if (weapons.Count > 0)
        {
            foreach (var weapon in weapons)
            {
                weapon.gameObject.SetActive(false);
            }
            weapons[0].gameObject.SetActive(true);
            _playerCombat.EquiWeapon(weapons[0]);
        }
    }

    public void SwapWeapon()
    {
        Weapon currentWeapon = _playerCombat.GetCurrentWeapon();
        if (currentWeapon == null)
            return;

        Weapon nextWeapon = null;

        foreach (var weapon in weapons)
        {
            if (weapon != currentWeapon && weapon.weaponData.weaponType != currentWeapon.weaponData.weaponType)
            {
                nextWeapon = weapon;
                break;
            }
        }

        if (nextWeapon == null)
        {
            Debug.LogWarning("No suitable weapon found to swap!");
            return;
        }

        // Disable current weapon
        currentWeapon.gameObject.SetActive(false);

        // Enable new weapon
        nextWeapon.gameObject.SetActive(true);

        // Tell PlayerCombat to use the new weapon
        _playerCombat.EquiWeapon(nextWeapon);

        Debug.Log("Swapped weapon to: " + nextWeapon.name);
    }

}

