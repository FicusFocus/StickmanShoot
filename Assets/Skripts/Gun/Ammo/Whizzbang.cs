using UnityEngine;

public class Whizzbang : Ammo
{
    [SerializeField] private ParticleSystem _bangEffect;
    [SerializeField] private float _affectedArea;

    protected override void OnTriggerEnter(Collider other)
    {
        Bang();
        base.OnTriggerEnter(other);
    }

    private void Bang()
    {
        Collider[] hitList = Physics.OverlapSphere(transform.position, _affectedArea);

        foreach (var hit in hitList)
        {
            if (hit.TryGetComponent(out Enemy enemy))
                enemy.TakeDamage();
        }

        Collider.enabled = false;
        _bangEffect.Play();
        Destroy(gameObject, _bangEffect.main.duration);
    }
}