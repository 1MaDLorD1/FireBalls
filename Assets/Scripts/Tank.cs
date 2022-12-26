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
    private Bullet _currentBullet;
    private bool _isLosedMenuOpen = false;

    public UnityAction<int> HPUpdated;

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
        if(_currentBullet != null)
            _currentBullet.ObstacleTouching -= OnObstacleTouching;

        _losedMenu.LosedMenuOpened -= OnLosedMenuOpened;
        _losedMenu.LosedMenuClosed -= OnLosedMenuClosed;
        _continueWithAdButton.RewardGot -= OnRewardGot;
    }

    private void Shoot()
    {
        _currentBullet = Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
        _currentBullet.ObstacleTouching += OnObstacleTouching;
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
        }
    }
}
