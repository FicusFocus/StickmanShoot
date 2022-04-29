using UnityEngine;

public class GunLevelTwo : Gun
{
    [SerializeField] private float _fireRate;

    private void OnEnable()
    {
        CurrentFireRate = _fireRate;
    }
}
