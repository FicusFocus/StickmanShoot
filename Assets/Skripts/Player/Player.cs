using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private EquipmentController _equipmentController;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Chamber _chamber;
    [SerializeField] private Gun _baceGun;
    [SerializeField] private float _backwardSpeed;
    [SerializeField] private float _sideSpeed;

    private bool _alreadyAttacked;
    private string _fall = "Fall";

    public event UnityAction Died;

    private void Start()
    {
        _mover.SetSideSpeedValue(_sideSpeed);
        _mover.SetTargetToMove(this);
        SetNewGun(_baceGun);
    }

    private void Update()
    {
        MoveBack();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent(out Pack pack))  //TODO: хуяня затея, переделать
        //{
        //    pack.Destroyed();
        //    pack.SetNewParrent(transform);

        //    if (pack.TryGetComponent(out AmmoPack ammo))
        //    {
        //        _chamber.TakeAmmo(ammo.AmmoInPack);
        //    }
        //    else
        //    {
                //if (pack.TryGetComponent(out BulletsPack bullets))
                //{
                //    _equipmentController.PutOnSniperEquipment();
                //}
                //else if (pack.TryGetComponent(out WhizzbangPack whizzbang))
                //{
                //    _equipmentController.PutOnGrenadierEquipment();
                //}
                //else if (pack.TryGetComponent(out GunLevelOnePack gunLevelUp))
                //{   //TODO: Разделить GunLevelUpPack по уровням.
                //    //_currentGun.LevelUp(gunLevelUp.UpFireRate);
                //    _equipmentController.PutOnGrenadierEquipment();
                //}

                ////_chamber.ChangeAmmoType(pack);
            //}
       // }
    } //ненужно скорее всего

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
            _chamber.StopShooting();
            Died?.Invoke();
        }
    }

    public void PutAmmoInChamber(int ammoCount)
    {
        if (ammoCount > 0)
        {
            _chamber.TakeAmmo(ammoCount);
        }
    }

    public void SetNewGun(Gun gun)
    {
        _chamber.SetNewGun(gun);
    }

    public void SetNewAmmoType(Ammo newAmmoType)
    {
        _chamber.SetNewAmmoType(newAmmoType);
    }
}
