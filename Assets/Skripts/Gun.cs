using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ShootEffectController _shootEffect;
    [SerializeField] private float _baseFireRate;
    [SerializeField] private int _maxGunLevel;

    private Ammo _currentAmmo;
    private int _gunLevel = 1;
    private float _currentFireRate;
    private float _timeAfterLastShoot;
    private bool _canSoot;

    public event UnityAction Shoted;

    private void Start() => _currentFireRate = _baseFireRate;

    private void Update()
    {
        _timeAfterLastShoot += Time.deltaTime;

        if (_timeAfterLastShoot >= _currentFireRate && _canSoot)
        {
            Shoot();
            _timeAfterLastShoot = 0;
        }
    }

    private void Shoot()
    {
        Instantiate(_currentAmmo, _shootPoint.position, Quaternion.identity);
        _shootEffect.PlayShootEffects();
        Shoted?.Invoke();
    }

    public void CanShoot(bool value)
    {
        _canSoot = value;
    }

    public void UpFireRate(float valueInPersent)
    {
        if (_gunLevel >= _maxGunLevel || valueInPersent > 1 || valueInPersent <= 0)
            return;

        _currentFireRate = _currentFireRate - ((float)_currentFireRate * valueInPersent);
        _gunLevel++;
    }

    public void SetAmmoType(Ammo ammoType)
    {
        _currentAmmo = ammoType;
    }
}
