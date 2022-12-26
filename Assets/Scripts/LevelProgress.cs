using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private float _filledDuration;
    [SerializeField] private Slider _slider;
    [SerializeField] private Tower _tower;
    [SerializeField] private TowerBuilder _builder;
    [SerializeField] private LevelPassedMenu _passedMenu;

    private float _towerStartSize;
    private float _timeAfterPass;

    private void Awake()
    {
        _towerStartSize = _builder.TowerSize;
        _slider.value = 0;
    }

    private void Update()
    {
        _timeAfterPass += Time.deltaTime;
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

        if(size == 0)
        {
            _passedMenu.gameObject.SetActive(true);
            _level.gameObject.SetActive(false);
        }
    }
}
