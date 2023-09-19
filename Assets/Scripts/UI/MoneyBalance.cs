using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyCount;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _moneyCount.text = _player.Money.ToString();
        _player.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyCount.text = money.ToString();
    }
}
