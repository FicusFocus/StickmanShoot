using UnityEngine;
using UnityEngine.Events;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] private ShootEffectController _shootEffect;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _baseFireRate;

    private Ammo _currentAmmo;
    private float _timeAfterLastShoot;
    private bool _canSoot;

    protected float CurrentFireRate;

    public event UnityAction Shoted;

    private void Start() => CurrentFireRate = _baseFireRate;

    private void Update()
    {
        _timeAfterLastShoot += Time.deltaTime;

        if (_timeAfterLastShoot >= CurrentFireRate && _canSoot)
        {
            Shoot();
            _timeAfterLastShoot = 0;
        }
    }

    protected virtual void Shoot()
    {
        Instantiate(_currentAmmo, _shootPoint.position, Quaternion.identity);
        _shootEffect.PlayShootEffects();
        Shoted?.Invoke();
    }

    public void CanShoot(bool value)
    {
        _canSoot = value;
    }

    public void SetAmmoType(Ammo ammoType)
    {
        _currentAmmo = ammoType;
    }
}
