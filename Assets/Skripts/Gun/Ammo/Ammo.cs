using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Ammo : MonoBehaviour
{
    [SerializeField] protected float Speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    protected abstract void OnTriggerEnter(Collider other);
}
