using UnityEngine;

public class BulletsPack : Pack
{
    [SerializeField] private ParticleSystem _dieEffect;

    public override void Destroyed()
    {
        _dieEffect.Play();
        base.Destroyed();
    }
}