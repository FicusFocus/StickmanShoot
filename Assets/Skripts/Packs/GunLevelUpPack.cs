using UnityEngine;

public class GunLevelUpPack : Pack
{
    [Range (0, 1)][SerializeField] private float _fireRateUpInPersent = 0.2f;

    public float UpFireRate => _fireRateUpInPersent;
}
