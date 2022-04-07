using UnityEngine;

public class ShootEffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _light;
    [SerializeField] private ParticleSystem _spark;

    public void PlayShootEffects()
    {
        _light.Play();
        _spark.Play();
    }
}
