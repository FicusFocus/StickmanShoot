using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : Ammo
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage();
            Destroy(gameObject);
        }
        else if (other.TryGetComponent(out DisactiveZone disactiveZone))
        {
            Destroy(gameObject);
        }
    }
}