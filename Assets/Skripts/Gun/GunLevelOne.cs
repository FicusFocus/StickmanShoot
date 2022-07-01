using System.Collections;
using UnityEngine;

public class GunLevelOne : Gun
{
    [SerializeField] private WaitForSeconds _fireRateInsideCycle = new WaitForSeconds(0.05f);
    [SerializeField] private int _shootPerCycle;

    private IEnumerator _shootCycle;

    protected override void Shoot()
    {
        if (_shootCycle == null)
        {
            _shootCycle = ShootCicle();
            StartCoroutine(_shootCycle);
        }
        else
        {
            StopCoroutine(_shootCycle);
            _shootCycle = null;
            _shootCycle = ShootCicle();
            StartCoroutine(_shootCycle);
        }
    }

    private IEnumerator ShootCicle()
    {
        for (int i = 0; i < _shootPerCycle; i++)
        {
            base.Shoot();
            yield return _fireRateInsideCycle;
        }
    }
}