using TMPro;
using UnityEngine;

public class AmmoPack : Pack
{
    [SerializeField] private TMP_Text _ammoCoutText;
    [SerializeField] private int _ammoInPack;

   // public int AmmoInPack => _ammoInPack;

    private void Start() 
    {
        _ammoCoutText.text = _ammoInPack.ToString();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.PutAmmoInChamber(_ammoInPack);
            base.OnTriggerEnter(other);
        }
    }
}