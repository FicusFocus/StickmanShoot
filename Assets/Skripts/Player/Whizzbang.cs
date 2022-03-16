using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Whizzbang : Ammo
{
    [SerializeField] private ParticleSystem _bangEffect;
    [SerializeField] private float _affectedArea;

    private void Bang()
    {
        Collider[] hitList = Physics.OverlapSphere(transform.position, _affectedArea);

        foreach (var hit in hitList)
        {
            if (hit.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage();
        }

        _bangEffect.Play();
        Destroy(gameObject, _bangEffect.main.duration);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        Bang();
    }
}