using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackDistance = 1f;
    [SerializeField] private float _speed;
    [SerializeField] private Player _target;
    [SerializeField] private Animator _animator;
    [SerializeField] private Material _enemyMaterial;
    [SerializeField] private Color _duyingColor;
    [SerializeField] private Color _normalColor;

    private bool _stopChasing = false;
    private NavMeshAgent _meshAgent;
    private string _attacktarget = "CanAttack";
    private string _dyuing = "Dyuing";
    private float _dyuingClipLanth = 4.6f;

    private void Start()
    {
        _enemyMaterial.color = _normalColor;
        _meshAgent = GetComponent<NavMeshAgent>();
        _meshAgent.speed = _speed;
    }

    private void Update()
    {
        if (_stopChasing)
        {
            _meshAgent.isStopped = true;
            return;
        }

        var targetPosition = _target.transform.position;
        _meshAgent.SetDestination(targetPosition);
        CheckDistanceTotarget(targetPosition);
    }

    private void CheckDistanceTotarget(Vector3 targetPosition)
    {
        var enemyPosition = transform.position;

        if (Vector3.Distance(enemyPosition, targetPosition) < _attackDistance)
            AttackTarget();
    }

    private void AttackTarget()
    {
        _animator.SetBool(_attacktarget, true);
        _target.Fall();
        _stopChasing = true;
    }

    private void Die()
    {
        _stopChasing = true;
        _enemyMaterial.color = _duyingColor;
        _animator.SetBool(_dyuing, true);
        Destroy(gameObject, _dyuingClipLanth);
    }

    public void TakeDamage()
    {
        Die();
    }
}
