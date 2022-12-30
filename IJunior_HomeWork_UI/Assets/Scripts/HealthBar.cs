using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Player _player;

    private float _rateChange = 10f;
    private float _currentValue;
    private Coroutine _activeCoroutine;

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
        _currentValue = _healthSlider.value;

        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _activeCoroutine = StartCoroutine(SmoothUpdate(health));
    }

    private IEnumerator SmoothUpdate(float health)
    {
        while (health != _currentValue)
        {
            _healthSlider.value = Mathf.MoveTowards(_currentValue, health, _rateChange * Time.deltaTime);
            _currentValue = _healthSlider.value;
            yield return null;
        }
    }
}
