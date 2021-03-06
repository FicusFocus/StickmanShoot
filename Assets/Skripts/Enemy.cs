using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [Range(0.1f, 2f), SerializeField] private float _attackDistance = 1f;
    [SerializeField] private SkinnedMeshRenderer _skin;
    [SerializeField] private Material _deadEnemyMaterial;
    [SerializeField] private Material _liveEnemyMaterial;
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private NavMeshAgent _meshAgent;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

    private Player _target;
    private bool _stopChasing = false;
    private float _dyuingClipLanth = 4.6f;
    private string _die = "Die";
    private string _attack = "Attack";

    public event UnityAction<Enemy> Died;

    private void Start()
    {
        _skin.material = _liveEnemyMaterial;
        _meshAgent.speed = _speed;
    }

    private void Update()
    {
        if (_stopChasing || _target == null)
            return;

        _meshAgent.SetDestination(_target.transform.position);
        CheckDistanceToTarget(_target.transform.position);
    }

    private void CheckDistanceToTarget(Vector3 targetPosition)
    {
        Vector3 myPosition = transform.position;

        if (Vector3.Distance(myPosition, targetPosition) < _attackDistance)
            AttackTarget();
    }

    private void AttackTarget()
    {
        _animator.SetTrigger(_attack);
        _target.Fall();
        StopChasing();
    }

    public void TakeDamage()
    {
        StopChasing();

        _skin.material = _deadEnemyMaterial;
        _animator.SetTrigger(_die);
        Died?.Invoke(this);
        _meshAgent.enabled = false;
        _collider.enabled = false;

        Destroy(gameObject, _dyuingClipLanth);
    }

    public void Init(Player target)
    {
        _target = target;
    }

    public void StopChasing()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
        _collider.isTrigger = true;
        _meshAgent.isStopped = true;
        _stopChasing = true;
    }
}