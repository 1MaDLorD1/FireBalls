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
    [SerializeField] private Saver _saver;

    private int _currentConfig;
    private LevelConfiguration _currentLevelConfiguration;
    private const string _nameLB = "Leaderboard";

    public int Score { get; set; }
    public int MaxScore { get; set; }

    private void Start()
    {
        if (DataHolder.IsStartButtonPressed)
        {
            _currentLevelConfiguration = _towerBuilder.CurrentConfiguration;
            _currentConfig = Array.IndexOf(DataHolder.LevelConfigurations, _currentLevelConfiguration);
            _currentScore.text = $"рейсыхи яв╗р: {Score}";
            _recordScore.text = $"пейнпд: {MaxScore}";
        }
    }

    private void OnEnable()
    {
        if (DataHolder.IsStartButtonPressed)
        {

            MaxScore = YandexGame.savesData.MaxScore;
            Score = YandexGame.savesData.CurrentScore;

            if (DataHolder.IsStartButtonPressed)
                _tank.ScoreUpdated += OnScoreUpdated;

            for (int i = 0; i < _quitInMenuButtons.Length; i++)
            {
                _quitInMenuButtons[i].ButtonPressed += OnButtonPressed;
            }

            _againButton.ButtonPressed += OnButtonPressed;
        }
    }

    private void OnDisable()
    {
        if (DataHolder.IsStartButtonPressed)
        {
            _tank.ScoreUpdated -= OnScoreUpdated;

            for (int i = 0; i < _quitInMenuButtons.Length; i++)
            {
                _quitInMenuButtons[i].ButtonPressed -= OnButtonPressed;
            }

            _againButton.ButtonPressed -= OnButtonPressed;

            _saver.MySave();
            YandexGame.NewLeaderboardScores(_nameLB, YandexGame.savesData.MaxScore);
        }
    }

    private void OnButtonPressed()
    {
        if (Score > MaxScore)
            MaxScore = Score;
        Score = 0;
    }

    private void OnScoreUpdated()
    {
        var rand = new System.Random();

        if (0 <= _currentConfig && _currentConfig < 4) Score += rand.Next(4, 6);
        else if (4 <= _currentConfig && _currentConfig < 8) Score += rand.Next(9, 11);
        else if (8 <= _currentConfig && _currentConfig < 12) Score += rand.Next(14, 16);
        else if (12 <= _currentConfig && _currentConfig < 16) Score += rand.Next(19, 21);
        else if (16 <= _currentConfig && _currentConfig < 20) Score += rand.Next(24, 26);
        else if (20 <= _currentConfig && _currentConfig < 24) Score += rand.Next(29, 31);
        else if (24 <= _currentConfig) Score += rand.Next(34, 36);

        _currentScore.text = $"рейсыхи яв╗р: {Score}";
    }
}
