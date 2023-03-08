using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MenuButtonClickAudio : MonoBehaviour
{
    [SerializeField] private StartButton _startButton;
    [SerializeField] private LevelsButton _levelsButton;
    [SerializeField] private BackButton _backButton;
    [SerializeField] private AudioClip _audioClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if(!DataHolder.isFirstOpen)
            _audioSource.PlayOneShot(_audioClip);

        DataHolder.isFirstOpen = false;
    }

    private void OnEnable()
    {
        _startButton.ButtonClicked += OnButtonClick;
        _levelsButton.ButtonClicked += OnButtonClick;
        _backButton.ButtonClicked += OnButtonClick;
    }

    private void OnDisable()
    {
        _startButton.ButtonClicked -= OnButtonClick;
        _levelsButton.ButtonClicked -= OnButtonClick;
        _backButton.ButtonClicked -= OnButtonClick;
    }

    private void OnButtonClick()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}
