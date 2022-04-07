using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private EquipmentController _equipmentController;
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
            pack.SetNewParrent(transform);

            if (pack.TryGetComponent(out AmmoPack ammo))
            {
                _chamber.TakeAmmo(ammo.AmmoInPack);
            }
            else
            {
                if (pack.TryGetComponent(out BulletsPack bullets))
                {
                    _equipmentController.PutOnSniperEquipment();
                }
                else if (pack.TryGetComponent(out WhizzbangPack whizzbang))
                {
                    _equipmentController.PutOnGrenadierEquipment();
                }
                else if (pack.TryGetComponent(out GunLevelUpPack gunLevelUp))
                {
                    _gun.UpFireRate(gunLevelUp.UpFireRate);
                    _equipmentController.PutOnGrenadierEquipment();
                }

                _chamber.ChangeAmmoType(pack);
            }
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
