using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _tamplates;
    [SerializeField] private Transform _tamplatesContainer;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _target;
    [SerializeField] private float _deleay;
    [SerializeField] private int _enemyesAmount;

    private Vector3 _enemySpwanPosition => _spawnPoint.position;
    private float _timeAfterLastSpawn = 0;
    private int _alreadySpawned = 0;

    private void Update()
    {
        if (_alreadySpawned == _enemyesAmount)
            gameObject.SetActive(false);

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _deleay)
        {
            SpawnEnemy();
            _alreadySpawned++;
            _timeAfterLastSpawn = 0;
        }
    }

    private void SpawnEnemy()
    {
        Enemy randomEnemy = _tamplates[Random.Range(0, _tamplates.Count)];
        var newEnemy = Instantiate(randomEnemy, _enemySpwanPosition, Quaternion.identity, _tamplatesContainer);
        newEnemy.Init(_target);
    }
}
