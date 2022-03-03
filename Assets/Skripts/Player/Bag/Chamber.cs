using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chamber : MonoBehaviour
{
    [SerializeField] private List<AmmoPackPlace> _packPlaces;
    [SerializeField] private Gun _gun;
    [SerializeField] private int _baseBulletsCount;
    [SerializeField] private TMP_Text _ammoCounter;

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
        _ammoCounter.text = _currentBulletsCount.ToString();
        SetAvtivePackPlace();

        if (_currentBulletsCount > 0)
            _gun.CanShoot(true);
    }

    private void SetAvtivePackPlace()
    {
        for (int i = 0; i < _currentBulletsCount / 2; i++)
            _packPlaces[i].gameObject.SetActive(true);

        for (int i = _currentBulletsCount; i < _packPlaces.Count; i++)
            _packPlaces[i].gameObject.SetActive(false);
    }

    private void OnGunShooted()
    {
        _currentBulletsCount--;
        _ammoCounter.text = _currentBulletsCount.ToString();
        SetAvtivePackPlace();

        if (_currentBulletsCount <= 0)
            _gun.CanShoot(false);
    }

    public void TakeAmmo(int value)
    {
        if (value > 0) 
        {
            if (value + _currentBulletsCount <= _maxBulletsCount)
                _currentBulletsCount += value;
            else
                _currentBulletsCount = _maxBulletsCount;
        }
    }
}
