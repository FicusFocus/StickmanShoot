using UnityEngine;

public abstract class Pack : MonoBehaviour
{
    [SerializeField] protected Collider _collider;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected AnimationClip _destroyClip;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            SetNewParrent(player.transform);
            Destroyed();
        }
    }

    protected virtual void Destroyed()
    {
        _collider.enabled = false;
        _animator.Play(_destroyClip.name);
        Destroy(gameObject, _destroyClip.length);
    }

    protected void SetNewParrent(Transform newParent)
    {
        transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;
    }
}