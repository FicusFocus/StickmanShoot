using UnityEngine;

public class WhizzbangPack : Pack
{
    [SerializeField] private ParticleSystem _dieEffect;
    [SerializeField] private Ammo _whizzbang;

    protected override void Destroyed()
    {
        _dieEffect.Play();
        base.Destroyed();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.SetNewAmmoType(_whizzbang);
            base.OnTriggerEnter(other);
        }
    }
}
