using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AgainButton : MonoBehaviour
{
    [SerializeField] private LevelLosedMenu _losedMenu;
    [SerializeField] private TowerBuilder _towerBuilder;

    private LevelConfiguration _currentConfiguration;

    private Button _button;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        _currentConfiguration = _towerBuilder.CurrentConfiguration;

        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        Game.Load(_currentConfiguration);
    }
}
