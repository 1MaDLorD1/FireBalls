using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AgainButton : MonoBehaviour
{
    [SerializeField] private LevelLosedMenu _losedMenu;
    [SerializeField] private TowerBuilder _towerBuilder;
    [SerializeField] private LevelConfiguration _firstLevel;

    private LevelConfiguration _currentConfiguration;
    private Button _button;

    public UnityAction ButtonPressed;

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
        ButtonPressed?.Invoke();
        Game.Load(_firstLevel);
    }

    private void HandleClickButtonCompanyGame()
    {
        Game.Load(_currentConfiguration);
    }
}
