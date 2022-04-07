using UnityEngine;

public abstract class Pack : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _destroyClip;

    public virtual void Destroyed()
    {
        Destroy(_collider);
        _animator.Play(_destroyClip.name);
        Destroy(gameObject, _destroyClip.length);
    }

    public void SetNewParrent(Transform newParent)
    {
        transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;
    }
}