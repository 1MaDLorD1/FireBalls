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
    [SerializeField] private LevelConfiguration _firstLevel;

    private LevelConfiguration _currentConfiguration;

    private Button _button;

    private void Start()
    {
        if (_button == null) _button = GetComponent<Button>();

        _currentConfiguration = _towerBuilder.CurrentConfiguration;

        if(DataHolder.IsStartButtonPressed)
            _button.onClick.AddListener(HandleClickButtonFreeGame);
        else
            _button.onClick.AddListener(HandleClickButtonCompanyGame);
    }

    private void HandleClickButtonFreeGame()
    {
        Game.Load(_firstLevel);
    }

    private void HandleClickButtonCompanyGame()
    {
        Game.Load(_currentConfiguration);
    }
}
