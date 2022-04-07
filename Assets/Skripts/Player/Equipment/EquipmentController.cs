using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    [SerializeField] private SniperEquipment _sniper;
    [SerializeField] private GrenadierEquipment _grenadier;

    private Equipment _currentEquipment;

    private void OnEnable()
    {
        _sniper.SetEquipmentEnabled(false);
        _grenadier.SetEquipmentEnabled(false);
    }

    public void PutOnSniperEquipment()
    {
        PutOnNewEquipment(_sniper);
    }

    public void PutOnGrenadierEquipment()
    {
        PutOnNewEquipment(_grenadier);
    }

    private void PutOnNewEquipment(Equipment newEquipment)
    {
        if (_currentEquipment == null)
        {
            _currentEquipment = newEquipment;
            _currentEquipment.SetEquipmentEnabled(true);
            return;
        }

        if (newEquipment == _currentEquipment)
            return;

        _currentEquipment.SetEquipmentEnabled(false);
        _currentEquipment = newEquipment;
        _currentEquipment.SetEquipmentEnabled(true);
    }
}
