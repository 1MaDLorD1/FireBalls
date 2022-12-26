using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class TowerBuilder : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    [SerializeField] private int _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] private Color[] _colors;

    private List<Block> _blocks;

    public LevelConfiguration CurrentConfiguration => _currentConfiguration;
    private LevelConfiguration _currentConfiguration;

    public ObstacleRotator ObstacleRotator => _obstacleRotator;
    private ObstacleRotator _obstacleRotator;

    public int TowerSize => _towerSize;

    public List<Block> Build()
    {
        _blocks = new List<Block>();

        Transform currentPoint = _buildPoint;

        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }

        return _blocks;
    }

    public void OnSceneLoaded(LevelConfiguration argument)
    {
        _currentConfiguration = argument;
        _towerSize = argument.TowerSize;
        _obstacleRotator = argument.ObstacleRotator;
    }

    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y / 2 + _block.transform.localScale.y / 2, _buildPoint.position.z);
    }
}
