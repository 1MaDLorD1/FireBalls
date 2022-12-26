using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ContinueWithAdButton : MonoBehaviour
{
    [SerializeField] private LevelLosedMenu _losedMenu;

    private Button _button;

    public UnityAction RewardGot;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        RewardGot?.Invoke();
        _losedMenu.gameObject.SetActive(false);
    }
}
