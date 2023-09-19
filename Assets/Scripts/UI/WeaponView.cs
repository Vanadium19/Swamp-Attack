using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    public event UnityAction<Weapon, WeaponView> OnSellButtonClicked;

    private Weapon _weapon;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockButton);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockButton);
    }

    public void InstantiateWeapon(Weapon weaponPrefab)
    {
        _weapon = Instantiate(weaponPrefab, transform);
        Render();
    }

    private void Render()
    {        
        _label.text = _weapon.Label;
        _price.text = _weapon.Price.ToString();
        _icon.sprite = _weapon.Icon;
    }

    private void TryLockButton()
    {
        if (_weapon.IsByued)
            _sellButton.interactable = false;
    }

    private void OnButtonClick()
    {
        OnSellButtonClicked?.Invoke(_weapon, this);
    }
}
