using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private LevelConfiguration _config;

    private Button _button;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        Game.Load(_config);
    }
}
