using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class SoundsOnOff : MonoBehaviour
{
    [SerializeField] private Sprite _soundsOn;
    [SerializeField] private Sprite _soundsOff;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Level _level;

    private Button _button;
    private Image _currentImage;
    private bool _isOn;

    private void Start()
    {
        _isOn = true;

        if (_currentImage == null) _currentImage = GetComponent<Image>();

        if (_button == null) _button = GetComponent<Button>();

        if (!_level.isActiveAndEnabled)
        {
            _button.onClick.AddListener(HandleClickButton);

            if (DataHolder.IsMusicOff)
            {
                _audioSource.volume = 0;
                _isOn = false;
                _currentImage.sprite = _soundsOff;
            }
            else
            {
                _audioSource.volume = 1;
                _isOn = true;
                _currentImage.sprite = _soundsOn;
            }
        }
        else
        {
            if (DataHolder.IsMusicOff)
            {
                _audioSource.volume = 0;
                _isOn = false;
            }
            else
            {
                _audioSource.volume = 1;
                _isOn = true;
            }
        }
    }

    private void HandleClickButton()
    {
        if (_isOn)
        {
            DataHolder.IsMusicOff = true;
            _audioSource.volume = 0;
            _isOn = false;
            _currentImage.sprite = _soundsOff;
        }
        else
        {
            DataHolder.IsMusicOff = false;
            _audioSource.volume = 1;
            _isOn = true;
            _currentImage.sprite = _soundsOn;
        }
    }
}
