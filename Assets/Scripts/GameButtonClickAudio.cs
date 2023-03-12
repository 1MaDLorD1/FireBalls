using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SoundsIndexes
{
    ClickButton,
    Shoot,
    BlockDestroy,
    ObstacleTouching,
    LevelLose,
    LevelComplete
}

[RequireComponent(typeof(AudioSource))]
public class GameButtonClickAudio : MonoBehaviour
{
    [SerializeField] private ContinueWithAdButton _continueWithAdButton;
    [SerializeField] private Tank _tank;
    [SerializeField] private LevelProgress _levelProgress;
    [SerializeField] private AudioClip[] _audioClips;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(_audioClips[(int)SoundsIndexes.ClickButton]);
    }

    private void OnEnable()
    {
        _continueWithAdButton.ButtonClicked += OnButtonClick;
        _tank.Shooted += OnShooted;
        _tank.Losed += OnLosed;
        _levelProgress.Passed += OnPassed;
    }

    private void OnDisable()
    {
        _continueWithAdButton.ButtonClicked -= OnButtonClick;
        _tank.Shooted -= OnShooted;
        _tank.Losed -= OnLosed;
        _levelProgress.Passed += OnPassed;

        if (_tank.CurrentBullet != null)
        {
            _tank.CurrentBullet.BlockDestroy -= OnBlockDestroy;
            _tank.CurrentBullet.ObstacleTouching -= OnObstacleTouching;
        }
    }

    private void OnButtonClick()
    {
        _audioSource.PlayOneShot(_audioClips[(int)SoundsIndexes.ClickButton]);
    }

    private void OnShooted()
    {
        _audioSource.PlayOneShot(_audioClips[(int)SoundsIndexes.Shoot]);
        _tank.CurrentBullet.BlockDestroy += OnBlockDestroy;
        _tank.CurrentBullet.ObstacleTouching += OnObstacleTouching;
    }

    private void OnBlockDestroy()
    {
        _audioSource.PlayOneShot(_audioClips[(int)SoundsIndexes.BlockDestroy]);
    }

    private void OnObstacleTouching()
    {
        _audioSource.PlayOneShot(_audioClips[(int)SoundsIndexes.ObstacleTouching]);
    }

    private void OnLosed()
    {
        _audioSource.PlayOneShot(_audioClips[(int)SoundsIndexes.LevelLose]);
    }

    private void OnPassed()
    {
        _audioSource.PlayOneShot(_audioClips[(int)SoundsIndexes.LevelComplete]);
    }
}
