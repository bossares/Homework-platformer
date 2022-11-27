using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delay = 2f;

    private void Start()
    {
        Initialize(_enemyPrefab);
        StartCoroutine(InstantiateEnemies());
    }

    private IEnumerator InstantiateEnemies()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_delay);
        Vector3 nextDirection = Vector3.left;

        while (true)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                if (TryGetObject(out GameObject enemy))
                    SetEnemy(enemy.GetComponent<Enemy>(), _spawnPoints[i].position, nextDirection);

                nextDirection = -nextDirection;

                yield return waitTime;
            }
        }
    }

    private void SetEnemy(Enemy enemy, Vector3 spawnPoint, Vector3 direction)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
        enemy.SetDirection(direction);
    }
}
