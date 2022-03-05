using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GunLevelUper : MonoBehaviour
{
    [Range (0, 1)][SerializeField] private float _fireRateUpInPersent = 0.2f;
    [SerializeField] private Gun _gun;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _gun.UpFireRate(_fireRateUpInPersent);
            Destroy(gameObject);
        }
    }
}
