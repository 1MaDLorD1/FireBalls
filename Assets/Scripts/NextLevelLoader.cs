using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private LevelConfiguration _config;

    private void OnEnable()
    {
        _tower.SizeUpdated += OnTowerSizeChanged;
    }

    private void OnDisable()
    {
        _tower.SizeUpdated -= OnTowerSizeChanged;
    }

    private void OnTowerSizeChanged(int size)
    {
        if (size == 0)
        {
            FirstLevel.Load(_config);
        }
    }
}
