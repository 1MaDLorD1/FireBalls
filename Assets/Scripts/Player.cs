using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Player : MonoBehaviour
{
    public Text TextPlayerName { get; }
    public ImageLoadYG ImageLoadPlayerPhoto { get; }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetPlayerName;

        if (YandexGame.SDKEnabled == true)
        {
            GetPlayerName();
        }
    }

    private void OnDisable() => YandexGame.GetDataEvent -= GetPlayerName;

    public void GetPlayerName()
    {
        if (TextPlayerName != null)
            TextPlayerName.text = YandexGame.playerName;

        if (ImageLoadPlayerPhoto != null && YandexGame.auth)
            ImageLoadPlayerPhoto.Load(YandexGame.playerPhoto);
    }
}
