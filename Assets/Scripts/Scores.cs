using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using YG;

public class Scores : MonoBehaviour
{
    [SerializeField] private TMP_Text _recordScore;
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private Tank _tank;
    [SerializeField] private TowerBuilder _towerBuilder;
    [SerializeField] private QuitInMenuButton[] _quitInMenuButtons;
    [SerializeField] private AgainButton _againButton;

    private int _score;
    private int _maxScore;
    private int currentConfig;
    private LevelConfiguration _currentLevelConfiguration;

    private void Start()
    {
        _currentLevelConfiguration = _towerBuilder.CurrentConfiguration;
        currentConfig = Array.IndexOf(DataHolder.LevelConfigurations, _currentLevelConfiguration);
        _currentScore.text = $"рейсыхи яв╗р: {_score}";
        _recordScore.text = $"пейнпд: {_maxScore}";
    }

    private void OnEnable()
    {
        _maxScore = YandexGame.savesData.MaxScore;
        _score = YandexGame.savesData.CurrentScore;

        if (DataHolder.IsStartButtonPressed)
            _tank.ScoreUpdated += OnScoreUpdated;

        for (int i = 0; i < _quitInMenuButtons.Length; i++)
        {
            _quitInMenuButtons[i].ButtonPressed += OnButtonPressed;
        }
        
        _againButton.ButtonPressed += OnButtonPressed;
    }

    private void OnDisable()
    {
        _tank.ScoreUpdated -= OnScoreUpdated;

        for (int i = 0; i < _quitInMenuButtons.Length; i++)
        {
            _quitInMenuButtons[i].ButtonPressed -= OnButtonPressed;
        }

        _againButton.ButtonPressed -= OnButtonPressed;

        YandexGame.savesData.CurrentScore = _score;
        YandexGame.savesData.MaxScore = _maxScore;
    }

    private void OnButtonPressed()
    {
        if (_score > _maxScore)
            _maxScore = _score;
        _score = 0;
    }

    private void OnScoreUpdated()
    {
        var rand = new System.Random();

        if (0 <= currentConfig && currentConfig < 4) _score += rand.Next(4, 6);
        else if (4 <= currentConfig && currentConfig < 8) _score += rand.Next(9, 11);
        else if (8 <= currentConfig && currentConfig < 12) _score += rand.Next(14, 16);
        else if (12 <= currentConfig && currentConfig < 16) _score += rand.Next(19, 21);
        else if (16 <= currentConfig && currentConfig < 20) _score += rand.Next(24, 26);
        else if (20 <= currentConfig && currentConfig < 24) _score += rand.Next(29, 31);
        else if (24 <= currentConfig) _score += rand.Next(34, 36);

        _currentScore.text = $"рейсыхи яв╗р: {_score}";
    }
}
