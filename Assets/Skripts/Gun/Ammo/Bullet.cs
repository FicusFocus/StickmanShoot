using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : Ammo
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage();
            base.OnTriggerEnter(other);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}