using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class EnemyWaweActivator : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyes;
    [SerializeField] private Player _target;

    public event UnityAction<Enemy> EnemyActivated;

    private void Awake()
    {
        foreach (Enemy enemy in _enemyes)
            enemy.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            ActivateEnemyes();
    }

    private void ActivateEnemyes()
    {
        foreach (Enemy enemy in _enemyes)
        {
            enemy.Init(_target);
            enemy.gameObject.SetActive(true);
            EnemyActivated?.Invoke(enemy);
        }
    }
}
