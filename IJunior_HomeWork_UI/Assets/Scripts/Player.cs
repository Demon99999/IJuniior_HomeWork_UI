using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _maxHealth = 100;
    private float _damage = 10;
    private float _heal = 10;

    public float MaxHealth => _maxHealth;

    public event UnityAction<float> HealthChanged;

    public void TakeDamage()
    {
        if (_health > 0)
        {
            _health -= _damage;
        }

        HealthChanged?.Invoke(_health);
    }

    public void TakeHeal()
    {
        if (_health < _maxHealth)
        {
            _health += _heal;
        }

        HealthChanged?.Invoke(_health);
    }
}
