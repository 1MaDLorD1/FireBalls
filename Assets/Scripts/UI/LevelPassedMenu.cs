using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LevelPassedMenu : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.SaveProgress();
    }
}
