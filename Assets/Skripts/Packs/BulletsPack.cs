using UnityEngine;

public class BulletsPack : Pack
{
    [SerializeField] private ParticleSystem _dieEffect;
    [SerializeField] private Ammo _bullets;

    protected override void Destroyed()
    {
        _dieEffect.Play();
        base.Destroyed();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.SetNewAmmoType(_bullets);
            base.OnTriggerEnter(other);
        }
    }
}