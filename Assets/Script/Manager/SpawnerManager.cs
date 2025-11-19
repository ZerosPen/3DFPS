using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager instance;

    private List<Transform> spawnPoints = new List<Transform>();
    public Transform spawPointParent;
    public GameObject enemyPrefab;
    public Transform enemyContainer;

    public int maxEnemySpawn;
    public int maxEnemyLimit = 5;

    private bool spawningLoopRunning = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < spawPointParent.childCount; i++)
            spawnPoints.Add(spawPointParent.GetChild(i));
    }

    public void BeginSpawnLoop()
    {
        if (!spawningLoopRunning)
            StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        spawningLoopRunning = true;

        while (true)
        {
            if (enemyContainer.childCount < maxEnemyLimit)
            {
                SpawnEnemies();
            }

            yield return new WaitForSeconds(5f);
        }
    }

    private void SpawnEnemies()
    {
        int enemySpawn = Random.Range(1, maxEnemySpawn);

        for (int i = 0; i < enemySpawn; i++)
        {
            Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Instantiate(enemyPrefab, randomSpawn.position, Quaternion.identity, enemyContainer);
        }
    }
}
