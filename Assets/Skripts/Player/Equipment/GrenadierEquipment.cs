using UnityEngine;

public class GrenadierEquipment : Equipment
{
    [SerializeField] private Helmet _helmet;
    [SerializeField] private KneePad _rightKneePad, _lefatKneePad;

    private void OnEnable()
    {
        EquipmentParts.Add(_helmet);
        EquipmentParts.Add(_rightKneePad);
        EquipmentParts.Add(_lefatKneePad);
    }
}
