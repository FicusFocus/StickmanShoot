using UnityEngine;

public abstract class Pack : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _destroyClip;

    public void Destroyed()
    {
        Destroy(_collider);
        _animator.Play(_destroyClip.name);
        Destroy(gameObject, _destroyClip.length);
    }
}