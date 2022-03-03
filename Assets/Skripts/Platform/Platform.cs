using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed => _speed;

    public event UnityAction PlatformDisativated;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void DisenabledPlatform()
    {
        PlatformDisativated?.Invoke();
        gameObject.SetActive(false);
    }
}
