using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Ammo : MonoBehaviour
{
    [SerializeField] protected float Speed;

    private bool _doMove = true;

    protected Collider Collider;

    private void Start()
    {
        Collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (_doMove)
            Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _doMove = false;
            transform.SetParent(enemy.transform);
        }
    }
}
