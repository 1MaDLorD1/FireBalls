using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class StartButton : MonoBehaviour
{
    [SerializeField] private LevelConfiguration _config;

    private Button _button;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        _button.onClick.AddListener(HandleClickButton);
    }

    private void OnEnable()
    {
        DataHolder.IsStartButtonPressed = false;
    }

    private void HandleClickButton()
    {
        DataHolder.IsStartButtonPressed = true;
        Game.Load(_config);
    }
}
