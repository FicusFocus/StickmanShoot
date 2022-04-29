using UnityEngine;
using TMPro;

public class Chamber : MonoBehaviour
{
    [Range(0, 200), SerializeField] private int _baseBulletsCount;
    [SerializeField] private AmmoPackPlace[] _packPlaces = new AmmoPackPlace[200];
    [SerializeField] private TMP_Text _ammoCounter;
    [SerializeField] private Ammo _startAmmoType;

    private Gun _currentGun;
    private Ammo _currentAmmoType;
    private int _currentBulletsCount;
    private int _maxBulletsCount => _packPlaces.Length;

    private void Start()
    {
        _currentAmmoType = _startAmmoType;
        _currentBulletsCount = _baseBulletsCount;
        SetAmmoCounerValue(_currentBulletsCount);
        SetAvtivePackPlace();

        if (_currentBulletsCount < 0)
            StopShooting();
    }

    private void SetAvtivePackPlace()
    {
        for (int i = 0; i < _packPlaces.Length; i++)
        {
            if (i < _currentBulletsCount)
                _packPlaces[i].gameObject.SetActive(true);
            else
                _packPlaces[i].gameObject.SetActive(false);
        }
    }

    private void OnGunShooted()
    {
        _currentBulletsCount--;
        SetAmmoCounerValue(_currentBulletsCount);
        SetAvtivePackPlace();

        if (_currentBulletsCount <= 0)
            _currentGun.CanShoot(false);
    }

    private void SetAmmoCounerValue(int value)
    {
        _ammoCounter.text = value.ToString();
    }

    public void TakeAmmo(int value)
    {
        if (value > 0) 
        {
            if (value + _currentBulletsCount <= _maxBulletsCount)
                _currentBulletsCount += value;
            else
                _currentBulletsCount = _maxBulletsCount;

            SetAmmoCounerValue(_currentBulletsCount);
            SetAvtivePackPlace();
            _currentGun.CanShoot(true);
        }
    }

    public void SetNewAmmoType(Ammo newAmmoType)
    {
        _currentAmmoType = newAmmoType;
        _currentGun.SetAmmoType(_currentAmmoType);
    }

    public void SetNewGun(Gun newGun)
    {
        if (_currentGun == null)
        {
            _currentGun = newGun;
            _currentGun.SetAmmoType(_currentAmmoType);
            _currentGun.Shoted += OnGunShooted;
        }
        else
        {
            _currentGun.Shoted -= OnGunShooted;
            _currentGun.gameObject.SetActive(false);
            _currentGun = newGun;
            _currentGun.SetAmmoType(_currentAmmoType);
            _currentGun.Shoted += OnGunShooted;
            _currentGun.gameObject.SetActive(true);
        }

        _currentGun.CanShoot(true);
    }

    public void StopShooting()
    {
        _currentGun.CanShoot(false);
    }
}