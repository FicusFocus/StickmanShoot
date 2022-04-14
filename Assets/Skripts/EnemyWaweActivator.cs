using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyWaweActivator : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyes;
    [SerializeField] private Player _target;

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
        }
    }
}
