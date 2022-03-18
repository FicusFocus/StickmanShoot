using UnityEngine;

public class SawTrap : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed;

    private Vector3 _lastTragetPosition;

    private void Start()
    {
        _lastTragetPosition = _endPoint.position;
    }

    private void Update()
    {
        if (_lastTragetPosition == _startPoint.position)
            MoveToPosition(_endPoint.position);
        else
            MoveToPosition(_startPoint.position);
    }

    private void MoveToPosition(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        CheckPosition(targetPosition);
    }

    private void CheckPosition(Vector3 targetPosition)
    {
        if (transform.position == targetPosition)
            _lastTragetPosition = targetPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Fall();
        }
    }
}
