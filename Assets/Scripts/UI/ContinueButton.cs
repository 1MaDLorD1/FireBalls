using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;
using System;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private TowerBuilder _towerBuilder;

    private Button _button;
    private LevelConfiguration _currentLevelConfiguration;
    private LevelConfiguration _nextLevelConfiguration;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        _currentLevelConfiguration = _towerBuilder.CurrentConfiguration;
        var currentConfig = Array.IndexOf(_levelManager.LevelConfigurations, _currentLevelConfiguration);

        if(currentConfig < _levelManager.LevelConfigurations.Length - 1)
            _nextLevelConfiguration = _levelManager.LevelConfigurations[currentConfig + 1];
        else
            _nextLevelConfiguration = _levelManager.LevelConfigurations[currentConfig];

        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        Game.Load(_nextLevelConfiguration);
    }
}
