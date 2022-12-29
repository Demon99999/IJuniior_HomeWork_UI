using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Player _player;

    private float _rate—hange = 3f;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _healthSlider.value = _player.MaxHealth;
        _healthSlider.maxValue = _player.MaxHealth;
    }

    private void OnHealthChanged(float health)
    {
        _healthSlider.DOValue(health,_rate—hange);
    }
}
