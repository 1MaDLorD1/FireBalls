using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private LevelConfiguration _config;
    [SerializeField] private LevelCellHolder _levelCellHolder;
    [SerializeField] private LevelManager _levelManager;

    private Button _button;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        Game.Load(_levelManager.LevelConfigurations[_levelCellHolder.CurrentId]);
    }
}
