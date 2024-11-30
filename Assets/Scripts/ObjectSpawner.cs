using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _coinGroup;
    [SerializeField]
    private GameObject[] _obstacles;
    [SerializeField]
    private Transform _spawnPointsParent;
    [SerializeField]
    private GameObject _planeMain;
    [SerializeField]
    private float _spawnInterval = 2.5f;

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
            SpawnObject();
            _timer = _spawnInterval;
        }
    }

    private void SpawnObject()
    {
        int randomIndex = Random.Range( 0, _spawnPoints.Length );
        Transform spawnPoint = _spawnPoints[randomIndex];

        float spawnChance = Random.value;
        if (spawnChance < 0.5f)
        {
            GameObject coinGroupInstance = Instantiate( _coinGroup, spawnPoint.position, spawnPoint.rotation );
            coinGroupInstance.transform.SetParent( _planeMain.transform );
        }
        else
        {
            int obstacleIndex = Random.Range( 0, _obstacles.Length );
            GameObject obstacleInstance = Instantiate( _obstacles[obstacleIndex], spawnPoint.position, spawnPoint.rotation );
            obstacleInstance.transform.SetParent( _planeMain.transform );
        }
    }
}
