using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
public class Enemy : MonoBehaviour
{    
    [Range (0.1f, 2f) ,SerializeField] private float _attackDistance = 1f;
    [SerializeField] private float _speed;
    [SerializeField] private Material _liveEnemyMaterial;
    [SerializeField] private Material _deadEnemyMaterial;
    [SerializeField] private SkinnedMeshRenderer _materialConteiner;
    [SerializeField] private Animator _animator;

    private NavMeshAgent _meshAgent;
    private Player _target;
    private bool _stopChasing = false;
    private float _dyuingClipLanth = 4.6f;
    private string _die = "Die";
    private string _attack = "Attack";
    private string _win = "Win";

    public event UnityAction<Enemy> Died;

    private void Start()
    {
        _materialConteiner.material = _liveEnemyMaterial;
        _meshAgent = GetComponent<NavMeshAgent>();
        _meshAgent.speed = _speed;
    }

    private void Update()
    {
        if (_stopChasing)
            return;

        _meshAgent.SetDestination(_target.transform.position);
        CheckDistanceTotarget(_target.transform.position);
    }

    private void CheckDistanceTotarget(Vector3 targetPosition)
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
        _meshAgent.isStopped = true;
        _stopChasing = true;
        _animator.SetTrigger(_attack);
    }
}