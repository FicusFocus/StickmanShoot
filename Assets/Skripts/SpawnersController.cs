using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SpawnersController : MonoBehaviour
{
    [SerializeField] private List<Spawner> _spawners;
    [SerializeField] private Player _target;

    private void Start()
    {
        foreach (Spawner spawner in _spawners)
            spawner.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            foreach(Spawner spawner in _spawners)
            {
                spawner.Init(_target);
                spawner.gameObject.SetActive(true);
            }
        }
    }
}
