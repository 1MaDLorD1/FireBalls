using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private float _filledDuration;
    [SerializeField] private Slider _slider;
    [SerializeField] private Tank _tank;

    private void Awake()
    {
        _slider.maxValue = _tank.HealthPoints;
        _slider.value = _tank.HealthPoints;
    }

    private void OnEnable()
    {
        _tank.HPUpdated += OnHPUpdated;
    }

    private void OnDisable()
    {
        _tank.HPUpdated -= OnHPUpdated;
    }

    private void OnHPUpdated(int hp)
    {
        _slider.DOValue(hp, _filledDuration);
    }
}
