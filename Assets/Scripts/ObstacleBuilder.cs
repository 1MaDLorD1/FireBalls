using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBuilder : MonoBehaviour
{
    [SerializeField] private TowerBuilder _towerBuilder;

    public void OnEnable()
    {
        Instantiate(_towerBuilder.ObstacleRotator, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.75f, gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
    }
}
