using UnityEngine;

public class WhizzbangPack : Pack
{
    [SerializeField] private ParticleSystem _dieEffect;

    public override void Destroyed()
    {
        _dieEffect.Play();
        base.Destroyed();
    }
}
