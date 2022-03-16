using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Chamber _chamber;
    [SerializeField] private float _backwardSpeed;
    [SerializeField] private float _sideSpeed;

    private Animator _animator;
    private bool _alreadyAttacked;
    private string _wasAttacked = "Fall";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _mover.SetSideSpeedValue(_sideSpeed);
        _mover.SetTargetToMove(this);
    }

    private void Update()
    {
        MoveBack();
    }

    private void MoveBack()
    {
        transform.Translate(Vector3.back * _backwardSpeed * Time.deltaTime);
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

    public void Fall()
    {
        if (_alreadyAttacked == false)
        {
            _animator.SetBool(_wasAttacked, true);
            _mover.SetSideSpeedValue(0);
            _backwardSpeed = 0;
            _alreadyAttacked = true;
        }
    }

    public void Die()
    {
        //TODO: доделать смерть.
    }
}
