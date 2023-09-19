using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private List<Weapon> _weaponPrefabs;
    [SerializeField] private WeaponView _weaponViewTemplate;
    [SerializeField] private Player _player;

    private void Start()
    {
        for (int i = 0; i < _weaponPrefabs.Count; i++)        
            AddItem(_weaponPrefabs[i]);        
    }

    private void AddItem(Weapon weaponPrefab)
    {
        var weaponView = Instantiate(_weaponViewTemplate, _itemContainer.transform);
        weaponView.InstantiateWeapon(weaponPrefab);
        weaponView.OnSellButtonClicked += OnSellButtonClicked;
    }

    private void OnSellButtonClicked(Weapon weapon, WeaponView weaponView)
    {
        if (TrySellWeapon(weapon));
            weaponView.OnSellButtonClicked -= OnSellButtonClicked;        
    }

    private bool TrySellWeapon(Weapon weapon)
    {
        bool canBuy = _player.TryBuyWeapon(weapon);

        if (_player.TryBuyWeapon(weapon))        
            _player.BuyWeapon(weapon);

        return canBuy;
    }
}
