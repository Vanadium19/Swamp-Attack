using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weaponsPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _inventory;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private List<Weapon> _weapons = new List<Weapon>();
    private int _currentHealth;
    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _money;

    public int Money => _money;

    private void Start()
    {
        foreach (var weaponPrefab in _weaponsPrefab)
        {
            var weapon = Instantiate(weaponPrefab, _inventory);
            _weapons.Add(weapon);
        }

        _currentWeapon = _weapons[_currentWeaponNumber];
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyChanged?.Invoke(_money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        _money -= weapon.Price;
        weapon.Buy();
        PutWeapon(weapon);
        MoneyChanged?.Invoke(_money);
    }

    public bool TryBuyWeapon(Weapon weapon)
    {
        return weapon.Price <= _money;
    }

    public void NextWeapon()
    {
        _currentWeaponNumber = _currentWeaponNumber == _weapons.Count - 1 ? 0 : ++_currentWeaponNumber;
        ChangeWeapon(_currentWeaponNumber);
    }

    public void PreviousWeapon()
    {
        _currentWeaponNumber = _currentWeaponNumber ==  0 ? _weapons.Count - 1 : --_currentWeaponNumber;
        ChangeWeapon(_currentWeaponNumber);
    }

    private void ChangeWeapon(int index)
    {
        _currentWeapon = _weapons[index];
    }

    private void PutWeapon(Weapon weapon)
    {
        weapon.transform.SetParent(_inventory);
        _weapons.Add(weapon);
    }
}
