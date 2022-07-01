using System.Collections.Generic;
using UnityEngine;

public class EnemyesController : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private List<EnemyWaweActivator> _wawe;

    private List<Enemy> _enemyes = new List<Enemy>();

    private void OnEnable()
    {
        _target.Died += OnTargetDied;

        foreach (EnemyWaweActivator wawe in _wawe)
            wawe.EnemyActivated += OnNewEnemySpawned;
    }

    private void OnDisable()
    {
        _target.Died -= OnTargetDied;

        foreach (EnemyWaweActivator wawe in _wawe)
            wawe.EnemyActivated -= OnNewEnemySpawned;
    }

    private void OnNewEnemySpawned(Enemy newEnemy)
    {
        newEnemy.Died += OnEnemyDied;
        _enemyes.Add(newEnemy);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _enemyes.Remove(enemy);
    }

    private void OnTargetDied()
    {
        foreach (Enemy enemy in _enemyes)
            enemy.StopChasing();
    }
}
