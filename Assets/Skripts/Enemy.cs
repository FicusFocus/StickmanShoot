using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [Range(0.1f, 2f), SerializeField] private float _attackDistance = 1f;
    [SerializeField] private Material _liveEnemyMaterial;
    [SerializeField] private Material _deadEnemyMaterial;
    [SerializeField] private SkinnedMeshRenderer _materialConteiner;
    [SerializeField] private Animator _animator;
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private Player _target;
    private float _yDiedPosition = -0.6f;
    private bool _stopChasing = false;
    private float _dyuingClipLanth = 4.6f;
    private string _die = "Die";
    private string _attack = "Attack";

    public event UnityAction<Enemy> Died;

    private void Start()
    {
        _materialConteiner.material = _liveEnemyMaterial;
        _meshAgent.speed = _speed;
    }

    private void Update()
    {
        if (_stopChasing)
            return;

        _meshAgent.SetDestination(_target.transform.position);
        CheckDistanceToTarget(_target.transform.position);
    }

    private void CheckDistanceToTarget(Vector3 targetPosition)
    {
        var enemyPosition = transform.position;

        if (Vector3.Distance(enemyPosition, targetPosition) < _attackDistance)
            AttackTarget();
    }

    private void AttackTarget()
    {
        _animator.SetTrigger(_attack);
        _target.Fall();
        StopChasing();
    }

    private void Die()
    {
        _materialConteiner.material = _deadEnemyMaterial;
        _stopChasing = true;
        _animator.SetTrigger(_die);
        Died?.Invoke(this);

        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(currentPosition.x, _yDiedPosition, currentPosition.z);

        Destroy(_meshAgent);
        Destroy(_collider);
        Destroy(_rigidbody);
        Destroy(gameObject, _dyuingClipLanth);
    }

    public void TakeDamage()
    {
        Die();
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void StopChasing()
    {
        _rigidbody.velocity = Vector3.zero;
        _collider.isTrigger = true;
        _meshAgent.isStopped = true;
        _stopChasing = true;
        _animator.SetTrigger(_attack);
    }
}