using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _shootEffect;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage();
            _shootEffect.Play();
            Destroy(gameObject);
        }
        else if(other.TryGetComponent(out DisactiveZone disactiveZone))
        {
            Destroy(gameObject);
        }
    }
}