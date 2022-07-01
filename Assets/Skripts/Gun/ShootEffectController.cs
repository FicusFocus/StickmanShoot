using UnityEngine;

public class ShootEffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _light;
    [SerializeField] private ParticleSystem _sparks;

    public void PlayShootEffects()
    {
        _light.Play();
        _sparks.Play();
    }
}
