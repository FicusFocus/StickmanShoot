using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMower _mower;
    [SerializeField] private Chamber _bag;
    [SerializeField] private float _speed;

    private Animator _animator;
    private bool _alreadyAttacked;
    private string _wasAttacked = "Fall";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveBack();
    }

    private void MoveBack()
    {
        transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }

    public void Fall()
    {
        if (_alreadyAttacked == false)
        {
            _animator.SetBool(_wasAttacked, true);
            _mower.SetSpeedValue(0);
            _speed = 0;
            _alreadyAttacked = true;
        }
    }

    public void Die()
    {
        //TODO: доделать смерть.
    }
}
