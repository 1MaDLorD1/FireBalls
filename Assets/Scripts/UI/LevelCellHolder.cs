using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;
using TMPro;

[RequireComponent(typeof(Button))]
public class LevelCellHolder : MonoBehaviour
{
    [SerializeField] private LevelConfiguration _config;
    [SerializeField] private Image _statusLevelIcon;
    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private int _levelIndex;

    private Button _button;

    public void Initialization(int id)
    {
        if (_button == null) _button = GetComponent<Button>();

        _levelIndex = id;

        _levelNumberText.text = _levelIndex.ToString();
        _button.onClick.AddListener(HandleClickButton);
    }

    private void HandleClickButton()
    {
        Game.Load(_config);
    }
}
