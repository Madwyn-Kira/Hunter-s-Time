using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private List<EntityController> _createdEnemies = new();
    private Transform _enemySpawnPosition;
    private int _maxEnemies = 5;

    private float _timeToSpawnEnemy = 8f;
    private float _timerForSpawnEnemies = 0f;

    public void Initialize(PlatformController platformController)
    {
        _enemySpawnPosition = platformController.EnemySpawnPosition;
        _maxEnemies = platformController.PlatformScriptableObject.MaxEnemiesOnPlatform;
        _timeToSpawnEnemy = platformController.PlatformScriptableObject.TimeToSpawnEnemy;
    }

    private void Update()
    {
        if (_createdEnemies.Count < _maxEnemies)
        {
            _timerForSpawnEnemies += Time.deltaTime;

            if (_timerForSpawnEnemies >= _timeToSpawnEnemy)
            {
                SpawnEnemy();
                _timerForSpawnEnemies = 0f;
            }
        }
    }

    private void SpawnEnemy()
    {
        int _rndEnemyPrefab = Random.Range(0, GameManager.Instance.EnemyPrefabsCollection.Count);

        var _enemy = Instantiate(GameManager.Instance.EnemyPrefabsCollection[_rndEnemyPrefab].EnemyPrefab, _enemySpawnPosition.position, Quaternion.identity);
        _enemy.InitializeEntity(GameManager.Instance.EnemyPrefabsCollection[_rndEnemyPrefab]);
        _enemy.OnEntityDestroy += RemoveEntityFromList;

        _createdEnemies.Add(_enemy);
    }

    private void RemoveEntityFromList(EntityController entity)
    {
        entity.OnEntityDestroy -= RemoveEntityFromList;
        _createdEnemies.Remove(entity);
    }
}
