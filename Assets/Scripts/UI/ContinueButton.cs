using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;
using System;
using UnityEngine.Events;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private TowerBuilder _towerBuilder;

    private Button _button;
    private LevelConfiguration _currentLevelConfiguration;
    private LevelConfiguration _nextLevelConfiguration;

    public UnityAction ButtonClicked;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        _currentLevelConfiguration = _towerBuilder.CurrentConfiguration;
        var currentConfig = Array.IndexOf(DataHolder.LevelConfigurations, _currentLevelConfiguration);

        if(currentConfig < DataHolder.LevelConfigurations.Length - 1)
            _nextLevelConfiguration = DataHolder.LevelConfigurations[currentConfig + 1];
        else
            _nextLevelConfiguration = DataHolder.LevelConfigurations[currentConfig];

        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        ButtonClicked?.Invoke();
        Game.Load(_nextLevelConfiguration);
    }
}
