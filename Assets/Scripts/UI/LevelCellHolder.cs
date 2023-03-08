using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;
using TMPro;
using UnityEngine.Events;

[RequireComponent(typeof(Button), typeof(AudioSource))]
public class LevelCellHolder : MonoBehaviour
{
    [SerializeField] private Image _statusLevelIcon;
    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private AudioClip _audioClip;

    private int _levelIndex;
    private Button _button;
    private LevelConfiguration _levelConfiguration;

    public int CurrentId => _currentId;
    private int _currentId;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

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
        _audioSource.PlayOneShot(_audioClip);
        _currentId = _levelIndex - 1;
        Game.Load(_levelConfiguration);
    }
}
