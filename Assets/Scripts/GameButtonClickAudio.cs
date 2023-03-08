using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GameButtonClickAudio : MonoBehaviour
{
    [SerializeField] private ContinueButton _continueButton;
    [SerializeField] private ContinueWithAdButton _continueWithAdButton;
    [SerializeField] private QuitInMenuButton[] _quitInMenuButtons;
    [SerializeField] private AgainButton _againButton;
    [SerializeField] private AudioClip _audioClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(_audioClip);
    }

    private void OnEnable()
    {
        _continueButton.ButtonClicked += OnButtonClick;
        _continueWithAdButton.ButtonClicked += OnButtonClick;
        _againButton.ButtonPressed += OnButtonClick;

        for (int i = 0; i < _quitInMenuButtons.Length; i++)
        {
            _quitInMenuButtons[i].ButtonPressed += OnButtonClick;
        }
    }

    private void OnDisable()
    {
        _continueButton.ButtonClicked -= OnButtonClick;
        _continueWithAdButton.ButtonClicked -= OnButtonClick;
        _againButton.ButtonPressed -= OnButtonClick;

        for (int i = 0; i < _quitInMenuButtons.Length; i++)
        {
            _quitInMenuButtons[i].ButtonPressed -= OnButtonClick;
        }
    }

    private void OnButtonClick()
    {
        _audioSource.PlayOneShot(_audioClip);
        Debug.Log("Êåê");
    }
}
