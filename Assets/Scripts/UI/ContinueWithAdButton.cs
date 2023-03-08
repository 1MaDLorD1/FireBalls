using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;

public class ContinueWithAdButton : MonoBehaviour
{
    [SerializeField] private LevelLosedMenu _losedMenu;

    private Button _button;

    public UnityAction RewardGot;
    public UnityAction ButtonClicked;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        _button.onClick.AddListener(HandleClickButton);
    }

    private void OnEnable()
    {
        YandexGame.ErrorVideoEvent += OnErrorVideoEvent;
        YandexGame.RewardVideoEvent += Rewarded;
    }

    private void OnDisable()
    {
        YandexGame.ErrorVideoEvent -= OnErrorVideoEvent;
        YandexGame.RewardVideoEvent -= Rewarded;
    }

    void OnErrorVideoEvent()
    {
        Debug.Log("Выключи адблок!");
    }

    void Rewarded(int id)
    {
        ButtonClicked?.Invoke();
        RewardGot?.Invoke();
        _losedMenu.gameObject.SetActive(false);
    }

    private void HandleClickButton()
    {
        YandexGame.RewVideoShow(0);
    }
}
