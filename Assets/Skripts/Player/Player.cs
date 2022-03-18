using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Chamber _chamber;
    [SerializeField] private Gun _gun;
    [SerializeField] private float _backwardSpeed;
    [SerializeField] private float _sideSpeed;

    private bool _alreadyAttacked;
    private string _fall = "Fall";

    public event UnityAction Died;

    private void Start()
    {
        _mover.SetSideSpeedValue(_sideSpeed);
        _mover.SetTargetToMove(this);
    }

    private void Update()
    {
        MoveBack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Pack pack))
        {
            pack.Destroyed();

            if (pack.TryGetComponent(out AmmoPack ammo))
                _chamber.TakeAmmo(ammo.AmmoInPack);
            else
                _chamber.ChangeAmmoType(pack);
        }
    }

    private void MoveBack()
    {
        transform.Translate(Vector3.back * _backwardSpeed * Time.deltaTime);
    }

    public void Fall()
    {
        if (_alreadyAttacked == false)
        {
            _animator.SetTrigger(_fall);
            _mover.SetSideSpeedValue(0);
            _backwardSpeed = 0;
            _alreadyAttacked = true;
            _gun.CanShoot(false);
            Died?.Invoke();
        }
    }
}
