using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using YG;

public class Saver : MonoBehaviour
{
	[SerializeField] private Scores _scores;

	private void OnEnable() => YandexGame.GetDataEvent += GetLoad;

	private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

	private void Start()
	{
		if (YandexGame.SDKEnabled == true)
		{
			GetLoad();
		}
	}

	public void GetLoad()
	{
		_scores.Score = YandexGame.savesData.CurrentScore;
		_scores.MaxScore = YandexGame.savesData.MaxScore;
	}


	public void MySave()
	{
		if(_scores.MaxScore > YandexGame.savesData.MaxScore)
			YandexGame.savesData.MaxScore = _scores.MaxScore;

		YandexGame.savesData.CurrentScore = _scores.Score;

		YandexGame.SaveProgress();
	}
}
