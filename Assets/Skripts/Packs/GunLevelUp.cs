using UnityEngine;

class GunLevelUp : Pack 
{
    [SerializeField] private Gun _gun;

    protected override void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent(out Player player))
        {
            player.SetNewGun(_gun);
            base.OnTriggerEnter(other);
        }
    }
}

