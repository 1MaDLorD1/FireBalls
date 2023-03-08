using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private LeaderboardYG _leaderboardYG;
    [SerializeField] private Text[] _entries;

    private int MaxScores = 7;

    public void NewScore()
    {
        YandexGame.NewLeaderboardScores(_leaderboardYG.nameLB, int.Parse(_player.TextPlayerName.text));
    }
}
