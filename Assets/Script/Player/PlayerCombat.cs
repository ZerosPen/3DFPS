using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private InputManager _inputManager;
    private PlayerUI _playerUI;
    private PlayerWeapon _playerWeapon;

    [Header("Equipped Weapon")]
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _currAmmo;

    [Header("Status")]
    private bool isAttacking;

    [Header("Events")]
    public OnUltimateActivedEventSO onUltimateActivedEvent;
    public OnUltimateDeactiveEventSO onUltimateDeactiveEvent;

    // Start is called before the first frame update
    void Start()
    {
        _inputManager = GetComponent<InputManager>();
        _playerUI = GetComponent<PlayerUI>();
        _playerWeapon = GetComponent<PlayerWeapon>();

        if (_currentWeapon != null)
        {
            _maxAmmo = _currentWeapon.weaponData.ammoCapacity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _currAmmo = Mathf.Clamp(_currAmmo, 0, _maxAmmo);
        if (_currentWeapon.weaponData.weaponType.ToString() == "Range")
        {
            _playerUI.UpdateAmmoUI(_currAmmo, _currentWeapon.weaponData.ammoCapacity);
        }
        else
        {
            _playerUI.UpdateAmmoUI(0, 0);
        }

        if (_inputManager.onFoot.Attack.triggered && _currentWeapon != null)
        {
            if (_currAmmo > 0 && _currentWeapon.weaponData.weaponType.ToString() == "Range")
            {
                _currentWeapon.PlayerAttack();
                _currAmmo -= 1;
            }
            else if (_currentWeapon.weaponData.weaponType.ToString() == "Melee")
            {
                _currentWeapon.PlayerAttack();
            }
        }

        if (_currAmmo <= 0 && _currentWeapon.weaponData.weaponType.ToString() != "Melee")
            _playerUI.UpdateText("Press R to Reload");

        if (_inputManager.onFoot.Reload.triggered && _currentWeapon != null && _currAmmo <= _maxAmmo)
            StartCoroutine(ReloadWeapon());
    }

    void ChangeWeapon()
    {
        Debug.Log("Change weapon!");
        _playerWeapon.SwapWeapon();
    }

    IEnumerator ReloadWeapon()
    {
        yield return new WaitForSeconds(_currentWeapon.weaponData.reloadTime);
        _playerUI.UpdateText(string.Empty);
        _currAmmo = _maxAmmo;
    }

    public void EquiWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;

        if (weapon.weaponData.weaponType.ToString() == "Range")
        {
            _maxAmmo  = weapon.weaponData.ammoCapacity;
            _currAmmo = weapon.weaponData.ammoCapacity;
        }
        else
        {
            _currAmmo = _maxAmmo = 0;
        }
    }

    public Weapon GetCurrentWeapon()
    {
        return _currentWeapon;
    }

    private void OnEnable()
    {
        onUltimateActivedEvent.OnUltimateActivedEvent += ChangeWeapon;
        onUltimateDeactiveEvent.OnUltimateDeactiveEvent += ChangeWeapon;
    }

    private void OnDisable()
    {
        onUltimateActivedEvent.OnUltimateActivedEvent -= ChangeWeapon;
        onUltimateDeactiveEvent.OnUltimateDeactiveEvent -= ChangeWeapon;
    }
}
