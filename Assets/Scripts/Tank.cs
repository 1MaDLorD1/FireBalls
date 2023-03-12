using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBetweenShoots;
    [SerializeField] private float _recoilDistance;
    [SerializeField] private int _healthPoints;
    [SerializeField] private LevelLosedMenu _losedMenu;
    [SerializeField] private ContinueWithAdButton _continueWithAdButton;

    public int HealthPoints => _healthPoints;

    private float _timeAfterShoot;
    private float _timeAfterObstacleTouch;
    private bool _isLosedMenuOpen = false;
    private Bullet _currentBullet;

    public Bullet CurrentBullet => _currentBullet;

    public UnityAction<int> HPUpdated;
    public UnityAction ScoreUpdated;
    public UnityAction Shooted;
    public UnityAction Losed;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;
        _timeAfterObstacleTouch += Time.deltaTime;

        if (Input.GetMouseButton(0) && !_isLosedMenuOpen)
        {
            if (_timeAfterShoot > _delayBetweenShoots)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweenShoots / 2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShoot = 0;
            }
        }
    }

    private void OnEnable()
    {
        _losedMenu.LosedMenuOpened += OnLosedMenuOpened;
        _losedMenu.LosedMenuClosed += OnLosedMenuClosed;
        _continueWithAdButton.RewardGot += OnRewardGot;
    }

    private void OnDisable()
    {
        if (_currentBullet != null)
        {
            _currentBullet.ObstacleTouching -= OnObstacleTouching;
            _currentBullet.BlockDestroy -= OnBlockDestroy;
        }
        
        _losedMenu.LosedMenuOpened -= OnLosedMenuOpened;
        _losedMenu.LosedMenuClosed -= OnLosedMenuClosed;
        _continueWithAdButton.RewardGot -= OnRewardGot;
    }

    private void Shoot()
    {
        _currentBullet = Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
        Shooted?.Invoke();
        _currentBullet.ObstacleTouching += OnObstacleTouching;
        _currentBullet.BlockDestroy += OnBlockDestroy;
    }

    private void OnLosedMenuOpened()
    {
        _isLosedMenuOpen = true;
    }

    private void OnLosedMenuClosed()
    {
        _isLosedMenuOpen = false;
    }

    private void OnRewardGot()
    {
        _healthPoints++;
        HPUpdated?.Invoke(_healthPoints);
    }

    private void OnObstacleTouching()
    {
        if (_healthPoints > 0 && _timeAfterObstacleTouch > 0.1f)
        {
            _healthPoints--;
            _timeAfterObstacleTouch = 0;
            HPUpdated?.Invoke(_healthPoints);
        }
        
        if(_healthPoints <= 0)
        {
            _losedMenu.gameObject.SetActive(true);
            Losed?.Invoke();
        }
    }

    private void OnBlockDestroy()
    {
        ScoreUpdated?.Invoke();
    }
}
