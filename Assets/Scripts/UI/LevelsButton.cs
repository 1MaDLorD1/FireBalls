using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsButton : MonoBehaviour
{
    [SerializeField] private Levels _levels;
    [SerializeField] private MainMenu _mainMenu;
    private Button _button;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        _levels.gameObject.SetActive(true);
        _mainMenu.gameObject.SetActive(false);
    }
}
