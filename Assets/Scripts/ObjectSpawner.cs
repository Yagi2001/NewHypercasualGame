using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _coinGroup;
    [SerializeField]
    private Transform _spawnPointsParent;
    [SerializeField]
    private float _spawnInterval = 2f;

    private Transform[] _spawnPoints;
    private float _timer;

    void Start()
    {
        _spawnPoints = new Transform[_spawnPointsParent.childCount];
        for (int i = 0; i < _spawnPointsParent.childCount; i++)
        {
            _spawnPoints[i] = _spawnPointsParent.GetChild( i );
        }

        _timer = _spawnInterval;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            SpawnCoinGroup();
            _timer = _spawnInterval; 
        }
    }

    private void SpawnCoinGroup()
    {
        int randomIndex = Random.Range( 0, _spawnPoints.Length );
        Instantiate( _coinGroup, _spawnPoints[randomIndex].position, _spawnPoints[randomIndex].rotation );
    }
}
