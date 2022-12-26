using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelCellHolder _levelCellHolderPrefab;
    [SerializeField] private Transform _contentLevelCells;
    [SerializeField] private LevelConfiguration[] _levelConfigurations;

    private List<LevelCellHolder> _levelCellHolders = new List<LevelCellHolder>();

    public LevelConfiguration[] LevelConfigurations => _levelConfigurations;

    private void Awake()
    {
        for (int i = 0; i < _levelConfigurations.Length; i++)
        {
            var levelCellHolder = Instantiate(_levelCellHolderPrefab, _contentLevelCells);
            levelCellHolder.Initialization(i, _levelConfigurations[i]);
            _levelCellHolders.Add(levelCellHolder);
        }
    }
}
