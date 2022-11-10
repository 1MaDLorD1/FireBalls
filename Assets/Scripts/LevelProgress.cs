using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private float _filledDuration;
    [SerializeField] private Slider _slider;
    [SerializeField] private Tower _tower;
    [SerializeField] private TowerBuilder _builder;

    private float _towerStartSize;

    private void Awake()
    {
        _towerStartSize = _builder.TowerSize;
        _slider.value = 0;
    }

    private void OnEnable()
    {
        _tower.SizeUpdated += OnSizeUpdated;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= OnSizeUpdated;
    }

    private void OnSizeUpdated(int size)
    {
        if (_towerStartSize != 0)
        {
            _slider.DOValue((_towerStartSize - size) / _towerStartSize, _filledDuration);
        }
    }
}
