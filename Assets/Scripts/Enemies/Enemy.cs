using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private float _delay;

    public event UnityAction<Enemy> Died;

    private Player _target;

    public Player Target => _target;
    public int Reward => _reward;
    public int Health => _health;

    public void Init(Player target)
    {
        _target = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject, _delay);
        GetComponent<BoxCollider2D>().enabled = false;
        Died?.Invoke(this);
    }
}
