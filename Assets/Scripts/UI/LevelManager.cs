using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelCellHolder _levelCellHolderPrefab;
    [SerializeField] private Transform _contentLevelCells;

    private const int _levelsCount = 28;
    private List<LevelCellHolder> _levelCellHolders = new List<LevelCellHolder>();

    private void Awake()
    {
        for (int i = 0; i < _levelsCount; i++)
        {
            var levelCellHolder = Instantiate(_levelCellHolderPrefab, _contentLevelCells);
            levelCellHolder.Initialization(i + 1);
            _levelCellHolders.Add(levelCellHolder);
        }
    }
}
