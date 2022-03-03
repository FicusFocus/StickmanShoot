using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Chamber _bag;
    [SerializeField] private float _speed;
    [SerializeField] private PlayerMower _mower;

    private bool _alreadyAttacked;
    private string _wasAttacked = "Fall";

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
