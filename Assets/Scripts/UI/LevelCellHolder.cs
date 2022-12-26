using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;
using TMPro;

[RequireComponent(typeof(Button))]
public class LevelCellHolder : MonoBehaviour
{
    [SerializeField] private Image _statusLevelIcon;
    [SerializeField] private TMP_Text _levelNumberText;

    private int _levelIndex;
    private Button _button;
    private LevelConfiguration _levelConfiguration;

    public int CurrentId => _currentId;
    private int _currentId;

    public void Initialization(int id, LevelConfiguration levelConfiguration)
    {
        if (_button == null) _button = GetComponent<Button>();

        _levelIndex = id + 1;
        _levelConfiguration = levelConfiguration;

        _levelNumberText.text = _levelIndex.ToString();
        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        _currentId = _levelIndex - 1;
        Game.Load(_levelConfiguration);
    }
}
