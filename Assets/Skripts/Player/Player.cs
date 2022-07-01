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

    private bool _attacked;
    private string _fall = "Fall";

    public event UnityAction Died;

    private void Start()
    {
        _mover.Init(this, _sideSpeed);
        SetNewGun(_baceGun);
    }

    private void Update()
    {
        if (_attacked)
            return;

        MoveBack();
    }

    private void MoveBack()
    {
        transform.Translate(Vector3.back * _backwardSpeed * Time.deltaTime);
    }

    public void Fall()
    {
        if (_attacked == false)
        {
            _animator.SetTrigger(_fall);
            _mover.SetSideSpeedValue(0);
            _backwardSpeed = 0;
            _attacked = true;
            _chamber.StopShooting();
            Died?.Invoke();
        }
    }

    public void PutAmmoInChamber(int ammoCount)
    {
        if (ammoCount > 0)
            _chamber.TakeAmmo(ammoCount);
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
