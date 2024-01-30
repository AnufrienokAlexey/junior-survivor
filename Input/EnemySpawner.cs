using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] private Transform player;
    public EnemySettings enemySettings;
    public float spawnInterval = 5f;

    private ObjectPool<Transform> enemyPool;
    public int enemyNumber = 10;

    public Transform[] spawnPoints; // Массив точек спауна

    void Start()
    {
        enemyPool = new ObjectPool<Transform>(enemyPrefab.transform, enemyNumber);
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        Transform enemyTransform = enemyPool.GetObject();

        Transform randomSpawnPoint = GetRandomSpawnPoint();
        enemyTransform.gameObject.SetActive(true);
        enemyTransform.position = randomSpawnPoint.position;
        enemyTransform.GetComponent<EnemyMovement>().Initialize(enemySettings, player);
    }

    Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

}