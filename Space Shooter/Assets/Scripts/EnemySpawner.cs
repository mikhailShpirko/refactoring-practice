using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    [SerializeField]
    private Enemy EnemyPrefab;

    [SerializeField]    
    private ObjectPool _pool;

    [SerializeField] 
    private int _spawnDelaySeconds;

    [SerializeField] 
    private int _maxEnemiesSpawn;
    private SpawnPoint[] _spawnPoints;  
    private float _lastSpawnTimeSeconds;

    private void Start()
    {
        _spawnPoints = FindObjectsOfType<SpawnPoint>();
        SpawnEnemies();
    }

    private void Update()
    {
        if (ShouldSpawn())
        {
            SpawnEnemies();
        }
    }
    private void SpawnEnemies()
    {
        _lastSpawnTimeSeconds = Time.time;
        for (int i = 0; i <= UnityEngine.Random.Range(0, _maxEnemiesSpawn); i++)
        {
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        var spawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)];
        var startPosition = spawnPoint.Position;
        _pool.GetFromPool<Enemy>(PoolObjectType.Enemy, startPosition, new Vector3(0,0,180));
    }

    private bool ShouldSpawn()
    {
        return _lastSpawnTimeSeconds + _spawnDelaySeconds < Time.time;
    }
}
