using UnityEngine;

public abstract class Pack : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationClip _destroyClip;

    protected virtual void Destroyed()
    {
        _collider.enabled = false;
        _animator.Play(_destroyClip.name);
        Destroy(gameObject, _destroyClip.length);
    }

    private void SetNewParrent(Transform newParent)
    {
        transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            SetNewParrent(player.transform);
            Destroyed();
        }
    }
}