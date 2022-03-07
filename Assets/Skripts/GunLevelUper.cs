using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GunLevelUper : MonoBehaviour
{
    [Range (0, 1)][SerializeField] private float _fireRateUpInPersent = 0.2f;
    [SerializeField] private Gun _gun;

    private float _destroyingScale;
    private Vector3 _increaseStep = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 _dyingTargetScale;
    private IEnumerator _destroyedProcess;

    private void Start()
    {
        _dyingTargetScale = transform.localScale * 2;
        _destroyingScale = _dyingTargetScale.x;
        _destroyedProcess = Destoying();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _gun.UpFireRate(_fireRateUpInPersent);
            StartCoroutine(_destroyedProcess);
        }
    }

    private IEnumerator Destoying()
    {
        while (transform.localScale.x <= _destroyingScale)
        {
            transform.localScale += _increaseStep;
            yield return null;
        }

        Destroy(gameObject);
    }
}
