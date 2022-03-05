using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chamber : MonoBehaviour
{
    [SerializeField] private List<AmmoPackPlace> _packPlaces;
    [SerializeField] private TMP_Text _ammoCounter;
    [SerializeField] private Gun _gun;
    [SerializeField] private int _baseBulletsCount;

    private int _currentBulletsCount;
    private int _maxBulletsCount => _packPlaces.Count;

    private void OnEnable()
    {
        _gun.Shoted += OnGunShooted;
    }

    private void OnDisable()
    {
        _gun.Shoted -= OnGunShooted;
    }

    private void Start()
    {
        _currentBulletsCount = _baseBulletsCount;
        SetAmmoCounerValue(_currentBulletsCount);
        SetAvtivePackPlace();

        if (_currentBulletsCount > 0)
            _gun.CanShoot(true);
    }

    private void SetAvtivePackPlace() //TODO хуета какаято непонятная, переделать
    {
        for (int i = 0; i < _currentBulletsCount / 2; i++)
            _packPlaces[i].gameObject.SetActive(true);

        for (int i = _currentBulletsCount; i < _packPlaces.Count; i++)
            _packPlaces[i].gameObject.SetActive(false);
    }

    private void OnGunShooted()
    {
        _currentBulletsCount--;
        SetAmmoCounerValue(_currentBulletsCount);
        SetAvtivePackPlace();

        if (_currentBulletsCount <= 0)
            _gun.CanShoot(false);
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
            _gun.CanShoot(true);
        }
    }
}
