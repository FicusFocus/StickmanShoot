using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _bigEnemyTemplate, _smallEnemyTamplate;
    [SerializeField] private Transform _templatesContainer;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _deleay;
    [SerializeField] private int _smallEnemyesAmount;
    [SerializeField] private int _bigEnemyesAmount;

    private Player _target;
    private Vector3 _enemySpwanPosition => _spawnPoint.position;
    private Enemy _lastSpawnedEnemy;
    private float _timeAfterLastSpawn = 0;
    private int _alreadySpawned = 0;
    private int _totalEnemyesAmount;
    private int _smallEnemyesSpawned, _bigEnemyesSpawned;

    public event UnityAction<Enemy> EnemySpawned;

    private void Start()
    {
        _totalEnemyesAmount = _smallEnemyesAmount + _bigEnemyesAmount;
    }

    private void Update()
    {
        if (_alreadySpawned == _totalEnemyesAmount)
            gameObject.SetActive(false);

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _deleay)
        {
            Enemy enemyToSpawn = SetEnemyTypeToSpawn();

            if (enemyToSpawn == null)
                return;

            SpawnEnemy(enemyToSpawn);
            _alreadySpawned++;
            _timeAfterLastSpawn = 0;
        }
    }

    private Enemy SetEnemyTypeToSpawn()
    {
        Enemy enemyToSpawn = null;

        if (_smallEnemyesSpawned < _smallEnemyesAmount)
        {
            _smallEnemyesSpawned++;
            return enemyToSpawn = _smallEnemyTamplate;
        }
        else if (_bigEnemyesSpawned < _bigEnemyesAmount)
        {
            _bigEnemyesSpawned++;
            return enemyToSpawn = _bigEnemyTemplate;
        }

        return enemyToSpawn;
    }

    private void SpawnEnemy(Enemy enemyType)
    {
        Enemy newEnemy = Instantiate(enemyType, _enemySpwanPosition, Quaternion.identity, _templatesContainer);
        _lastSpawnedEnemy = enemyType;
        newEnemy.Init(_target);
        EnemySpawned?.Invoke(newEnemy);
    }

    public void Init(Player target)
    {
        _target = target;
    }
}
