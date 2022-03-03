using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _baseAttackSpeed;

    private float _currentAttackSpeed;
    private float _timeAfterLastShoot;
    private bool _canSoot;

    public event UnityAction Shoted;

    private void Start()
    {
        _currentAttackSpeed = _baseAttackSpeed;
    }

    private void Update()
    {
        _timeAfterLastShoot += Time.deltaTime;

        if (_timeAfterLastShoot >= _currentAttackSpeed && _canSoot)
        {
            Shoot();
            _timeAfterLastShoot = 0;
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        Shoted?.Invoke();
    }

    public void CanShoot(bool value)
    {
        _canSoot = value;
    }
}
