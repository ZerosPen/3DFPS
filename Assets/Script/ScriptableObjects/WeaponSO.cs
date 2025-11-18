using UnityEngine;

[System.Serializable]
public enum WeaponType
{
    Range,
    Melee
}

[CreateAssetMenu(menuName = ("WeaponSO"))]
public class WeaponSO : ScriptableObject
{
    [Header("Description Weapon")]
    public string weaponName;
    public WeaponType weaponType;

    // Range fields
    public int ammoCapacity;
    public float reloadTime;
    public float fireRate;

    // Melee fields
    public float meleeDamage;
    public float swingTime;
}
